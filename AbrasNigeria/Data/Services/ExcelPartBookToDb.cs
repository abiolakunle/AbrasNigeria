using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Services
{
    public class ExcelPartBookToDb
    {
        private readonly PartsBookDbContext _dbContext;
        private readonly IHostingEnvironment _environment;

        public ExcelPartBookToDb(PartsBookDbContext dbContext, IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }


        public async Task CopyToDbNew(IFormFile masterFile)
        {
            //Generate full filepath and save file
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _environment.WebRootPath, "uploads/" + masterFile.FileName);

            using (var bits = new FileStream(filePath, FileMode.Create))
            {
                await masterFile.CopyToAsync(bits);
            }

            //create new file object from file path
            FileInfo file = new FileInfo(filePath);

            //Install-Package EPPlus.Core -Version 1.5.4
            using (ExcelPackage package = new ExcelPackage(file))
            {
                //get file as worksheet object
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];

                //get master table line objects with properties of excel table columns
                HashSet<MasterTableLine> masterLines = SheetToTableLine(workSheet);

                //delete file
                file.Delete();

                //Relationship HashSets
                HashSet<MachineSection> memMachineSections = new HashSet<MachineSection>();
                HashSet<MachineSectionGroup> memMachineSectionGroups = new HashSet<MachineSectionGroup>();
                HashSet<ProductSectionGroup> memProductSectionGroups = new HashSet<ProductSectionGroup>();
                HashSet<ProductDescription> memProductDescriptions = new HashSet<ProductDescription>();

                //sort out some relationships (in memory)
                foreach (MasterTableLine line in masterLines.Reverse())
                {
                    if (!memMachineSections.Any(ms => ms.Machine.ModelName == line.ModelName && ms.Section.SectionName == line.Section))
                    {
                        memMachineSections.Add(new MachineSection
                        {
                            Machine = new Machine { ModelName = line.ModelName },
                            Section = new Section { SectionName = line.Section }
                        });
                    }
                    Console.WriteLine($"ms Length {memMachineSections.Count()}");

                    if (!memMachineSectionGroups.Any(msg => msg.Machine.ModelName == line.ModelName && msg.SectionGroup.SectionGroupName == line.SectionGroup))
                    {
                        memMachineSectionGroups.Add(new MachineSectionGroup
                        {
                            Machine = new Machine { ModelName = line.ModelName },
                            SectionGroup = new SectionGroup { SectionGroupName = line.SectionGroup }
                        });
                    }
                    Console.WriteLine($"psg Length {memMachineSectionGroups.Count()}");

                    if (!memProductSectionGroups.Any(psg => psg.Product.PartNumber == line.PartNumber && psg.SectionGroup.SectionGroupName == line.SectionGroup))
                    {
                        memProductSectionGroups.Add(new ProductSectionGroup
                        {
                            Product = new Product { PartNumber = line.PartNumber },
                            SectionGroup = new SectionGroup { SectionGroupName = line.SectionGroup }
                        });
                    }
                    Console.WriteLine($"ps Length {memProductSectionGroups.Count()}");

                    if (!memProductDescriptions.Any(pd => pd.Product.PartNumber == line.PartNumber && pd.Description.DescriptionName == line.Description))
                    {
                        memProductDescriptions.Add(new ProductDescription
                        {
                            Product = new Product { PartNumber = line.PartNumber },
                            Description = new Description { DescriptionName = line.Description }
                        });
                    }
                    Console.WriteLine($"ps Length {memProductSectionGroups.Count()}");
                }

                string prevBrand = null;
                string prevMachine = null;
                string prevSection = null;
                string prevSectionGroup = null;
                string prevDescription = null;
                string prevProduct = null;

                //hold current entity
                Brand brand = null;
                Machine machine = null;
                Section section = null;
                SectionGroup sectionGroup = null;
                Description description = null;
                Product product = null;

                //get data to db
                foreach (var line in masterLines)
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    //add brand
                    if (line.Brand != "")
                    {
                        Console.WriteLine($"PrevBrand = {prevBrand} CurrentBrand = {line.Brand}");

                        if (prevBrand != line.Brand)
                        {
                            Console.WriteLine("About to get Brand");
                            brand = _dbContext.Brands.FirstOrDefault(b => b.Name == line.Brand);
                            if (brand == null)
                            {
                                _dbContext.Brands.Add(new Brand
                                {
                                    Name = line.Brand
                                });
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added brand");
                                brand = _dbContext.Brands.Where(b => b.Name == line.Brand).FirstOrDefault();
                            }
                            prevBrand = line.Brand;
                        }
                    }

                    //add machine model
                    if (line.ModelName != "")
                    {
                        Console.WriteLine($"PrevMach = {prevMachine} CurrentMach = {line.ModelName}");

                        if (prevMachine != line.ModelName)
                        {
                            machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();

                            if (machine == null)
                            {
                                _dbContext.Machines.Add(new Machine
                                {
                                    ModelName = line.ModelName,
                                    SerialNumber = line.MachineSerialNumber,
                                    Brand = brand
                                });
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added machine");
                                machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();
                            }
                            prevMachine = line.ModelName;
                        }
                    }

                    //add Section
                    if (line.Section != "")
                    {

                        if (prevSection != line.Section)
                        {
                            section = _dbContext.Sections.Where(s => s.SectionName == line.Section).FirstOrDefault();

                            if (section == null)
                            {
                                _dbContext.Sections.Add(new Section
                                {
                                    SectionName = line.Section
                                });
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added section");
                                section = _dbContext.Sections.Where(s => s.SectionName == line.Section).FirstOrDefault();
                            }
                            prevSection = line.Section;
                        }
                    }

                    //add SectionGroup
                    if (line.SectionGroup != "")
                    {
                        if (prevSectionGroup != line.SectionGroup)
                        {
                            sectionGroup = _dbContext.SectionGroups.Where(s => s.SectionGroupName == line.SectionGroup).FirstOrDefault();

                            if (sectionGroup == null)
                            {
                                _dbContext.SectionGroups.Add(new SectionGroup
                                {
                                    SectionGroupName = line.SectionGroup,
                                    Section = section
                                });
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added sectiongroup");
                                sectionGroup = _dbContext.SectionGroups.Where(s => s.SectionGroupName == line.SectionGroup).FirstOrDefault();
                            }
                            prevSectionGroup = line.SectionGroup;
                        }
                    }

                    //add description
                    if (line.Description != "")
                    {
                        if (prevDescription != line.Description)
                        {
                            description = _dbContext.Descriptions.Where(c => c.DescriptionName == line.Description).FirstOrDefault();

                            if (description == null)
                            {
                                _dbContext.Descriptions.Add(new Description
                                {
                                    DescriptionName = line.Description,
                                });
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added description");
                                description = _dbContext.Descriptions.Where(c => c.DescriptionName == line.Description).FirstOrDefault();
                            }

                            prevDescription = line.Description;
                        }
                    }

                    //add partnumber
                    if (line.PartNumber != "")
                    {
                        if (prevProduct != line.PartNumber)
                        {
                            product = _dbContext.Products.FirstOrDefault(p => p.PartNumber == line.PartNumber);

                            if (product == null)
                            {
                                _dbContext.Products.Add(new Product
                                {
                                    PartNumber = line.PartNumber,
                                    Brand = brand,
                                    Section = section,
                                });
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added product");
                                product = _dbContext.Products.Where(p => p.PartNumber == line.PartNumber).FirstOrDefault();
                            }
                            prevProduct = line.PartNumber;
                        }

                    }


                    //Sort out many to many relationships

                    //ProductMachine relationship
                    bool machineSectionGroupProductBool = _dbContext
                        .Set<MachineSectionGroupProduct>()
                        .Any(pm => pm.ProductId == product.ProductId && pm.MachineId == machine.MachineId && pm.SectionGroupId == sectionGroup.SectionGroupId);

                    if (!machineSectionGroupProductBool)
                    {
                        //product.MachineSectionGroups.Add(machineSectionGroupProduct);
                        machine.SectionGroupProducts.Add(new MachineSectionGroupProduct
                        {
                            Product = product,
                            SectionGroup = sectionGroup,
                            Machine = machine,
                        });
                        _dbContext.SaveChanges();
                    }

                    //ProductDescription relationship
                    var prodDesc = memProductDescriptions
                        .FirstOrDefault(pd => pd.Product.PartNumber == line.PartNumber && pd.Description.DescriptionName == line.Description);
                    if (prodDesc != null)
                    {
                        bool productDescriptionBool = _dbContext
                            .Set<ProductDescription>()
                            .Any(pc => pc.ProductId == product.ProductId && pc.DescriptionId == description.DescriptionId);

                        if (!productDescriptionBool)
                        {
                            product.Descriptions.Add(new ProductDescription
                            {
                                Product = product,
                                Description = description
                            });
                            _dbContext.SaveChanges();
                        }
                        memProductDescriptions.Remove(prodDesc);
                    }


                    //ProductSectionGroup relationship
                    var proSectGrp = memProductSectionGroups
                        .FirstOrDefault(psg => psg.Product.PartNumber == line.PartNumber && psg.SectionGroup.SectionGroupName == line.SectionGroup);
                    if (proSectGrp != null)
                    {
                        bool productSectionGroupBool = _dbContext
                            .Set<ProductSectionGroup>()
                            .Any(psg => psg.SectionGroupId == sectionGroup.SectionGroupId && psg.ProductId == product.ProductId);

                        if (!productSectionGroupBool)
                        {
                            product.SectionGroups.Add(new ProductSectionGroup
                            {
                                Product = product,
                                SectionGroup = sectionGroup
                            });
                            _dbContext.SaveChanges();
                        }
                        memProductSectionGroups.Remove(proSectGrp);
                    }

                    //MachineSection relationship
                    var mcSect = memMachineSections
                        .FirstOrDefault(ms => ms.Machine.ModelName == line.ModelName && ms.Section.SectionName == line.Section);
                    if (mcSect != null)
                    {
                        bool machineSectionBool = _dbContext
                        .Set<MachineSection>()
                        .Any(m => m.MachineId == machine.MachineId && m.SectionId == section.SectionId);

                        if (!machineSectionBool)
                        {
                            machine.Sections.Add(new MachineSection
                            {
                                Section = section,
                                Machine = machine
                            });
                            _dbContext.SaveChanges();
                        }
                        memMachineSections.Remove(mcSect);
                    }

                    //MachineSectionGroup relationship
                    var mcSectGrp = memMachineSectionGroups
                        .FirstOrDefault(msg => msg.Machine.ModelName == line.ModelName && msg.SectionGroup.SectionGroupName == line.SectionGroup);
                    if (mcSectGrp != null)
                    {
                        bool machineSectionGroupBool = _dbContext
                        .Set<MachineSectionGroup>()
                        .Any(m => m.MachineId == machine.MachineId && m.SectionGroupId == sectionGroup.SectionGroupId);

                        Console.WriteLine($"machSectBool: {!machineSectionGroupBool}");

                        if (!machineSectionGroupBool)
                        {
                            machine.SectionGroups.Add(new MachineSectionGroup
                            {
                                SectionGroup = sectionGroup,
                                Machine = machine
                            });
                            _dbContext.SaveChanges();
                        }
                        memMachineSectionGroups.Remove(mcSectGrp);
                    }

                    Console.WriteLine($"Queries Time: {sw.ElapsedMilliseconds} ms");

                }
            }
        }

        public async Task CopyToDb(IFormFile masterFile)
        {
            //Generate full filepath and save file
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _environment.WebRootPath, "uploads/" + masterFile.FileName);

            using (var bits = new FileStream(filePath, FileMode.Create))
            {
                await masterFile.CopyToAsync(bits);
            }

            //create new file object from file path
            FileInfo file = new FileInfo(filePath);

            //Install-Package EPPlus.Core -Version 1.5.4
            using (ExcelPackage package = new ExcelPackage(file))
            {
                //get file as worksheet object
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];

                //get master table line objects with properties of excel table columns
                HashSet<MasterTableLine> masterLines = SheetToTableLine(workSheet);

                //delete file
                file.Delete();

                //cycle count
                int count = 0;

                string prevBrand = null;
                string prevMachine = null;
                string prevSection = null;
                //string prevSectionGroup = null;
                //string prevCategory = null;
                //string prevProduct = null;

                //get data to db
                foreach (var line in masterLines)
                {
                    Console.WriteLine("Cycle" + count);
                    DateTime startTime = DateTime.Now;

                    if (line.Brand != "")
                    {
                        Console.WriteLine($"PrevBrand = {prevBrand} CurrentBrand = {line.Brand}");

                        if (prevBrand != line.Brand)
                        {
                            Console.WriteLine("About to get Brand");
                            Brand brand = _dbContext.Brands.FirstOrDefault(b => b.Name == line.Brand);
                            if (brand == null)
                            {
                                brand = new Brand
                                {
                                    Name = line.Brand
                                };

                                _dbContext.Brands.Add(brand);
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added brand");
                                //brand = _dbContext.Brands.Where(b => b.Name == line.Brand).FirstOrDefault();
                            }
                            prevBrand = line.Brand;
                        }

                        //Install - Package FlexLabs.EntityFrameworkCore.Upsert - Version 2.1.2
                        //_dbContext.Upsert(brand).On(b => new { b.Name }).Run();

                        if (line.ModelName != "")
                        {
                            Console.WriteLine($"PrevMach = {prevMachine} CurrentMach = {line.ModelName}");

                            if (prevMachine != line.ModelName)
                            {
                                Machine machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();

                                if (machine == null)
                                {
                                    machine = new Machine
                                    {
                                        ModelName = line.ModelName,
                                        SerialNumber = line.MachineSerialNumber,
                                        Brand = _dbContext.Brands.FirstOrDefault(b => b.Name == line.Brand)
                                    };
                                    _dbContext.Machines.Add(machine);
                                    _dbContext.SaveChanges();
                                    Console.WriteLine("Added machine");
                                    //machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();
                                }

                                prevMachine = line.ModelName;
                            }

                            if (line.Section != "")
                            {
                                Section section = _dbContext.Sections.Where(s => s.SectionName == line.Section).FirstOrDefault();

                                if (prevSection == line.Section)
                                {
                                    if (section == null)
                                    {
                                        section = new Section
                                        {
                                            SectionName = line.Section
                                        };

                                        _dbContext.Sections.Add(section);
                                        _dbContext.SaveChanges();
                                        Console.WriteLine("Added section");
                                        section = _dbContext.Sections.Where(s => s.SectionName == line.Section).FirstOrDefault();
                                    }
                                }

                                if (line.SectionGroup != "")
                                {
                                    SectionGroup sectionGroup = _dbContext.SectionGroups.Where(s => s.SectionGroupName == line.SectionGroup).FirstOrDefault();

                                    if (sectionGroup == null)
                                    {
                                        sectionGroup = new SectionGroup
                                        {
                                            SectionGroupName = line.SectionGroup,
                                            Section = section
                                        };

                                        _dbContext.SectionGroups.Add(sectionGroup);
                                        _dbContext.SaveChanges();
                                        Console.WriteLine("Added sectiongroup");
                                        //_dbContext.SectionGroups.Where(s => s.SectionGroupName == line.SectionGroup).FirstOrDefault();
                                    }

                                    //_dbContext.SectionGroups.Upsert(sectionGroup).On(s => new { s.SectionGroupName }).Run();

                                    if (line.Description != "")
                                    {
                                        Description description = _dbContext.Descriptions.Where(c => c.DescriptionName == line.Description).FirstOrDefault();

                                        if (description == null)
                                        {
                                            description = new Description
                                            {
                                                DescriptionName = line.Description,
                                            };
                                            _dbContext.Descriptions.Add(description);
                                            _dbContext.SaveChanges();
                                            Console.WriteLine("Added description");
                                            //description = _dbContext.Descriptions.Where(c => c.DescriptionName == line.Description).FirstOrDefault();
                                        }

                                        //_dbContext.Descriptions.Upsert(description).On(s => new { s.DescriptionName }).Run();

                                        if (line.PartNumber != "")
                                        {
                                            Product product = _dbContext.Products.FirstOrDefault(p => p.PartNumber == line.PartNumber);

                                            if (product == null)
                                            {
                                                product = new Product
                                                {
                                                    PartNumber = line.PartNumber,
                                                    Brand = _dbContext.Brands.FirstOrDefault(b => b.Name == line.Brand),
                                                    Section = section,
                                                };
                                                _dbContext.Products.Add(product);
                                                _dbContext.SaveChanges();
                                                Console.WriteLine("Added product");
                                                //product = _dbContext.Products.Where(p => p.PartNumber == line.PartNumber).FirstOrDefault();
                                            }

                                            //_dbContext.Products.Upsert(product).On(s => new { s.PartNumber }).Run();

                                            //Sort out many to many relationships
                                            Machine machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();

                                            //ProductSectionGroup relationship
                                            ProductSectionGroup productSectionGroup = _dbContext
                                                .Set<ProductSectionGroup>()
                                                .Where(psg => psg.SectionGroupId == sectionGroup.SectionGroupId && psg.ProductId == product.ProductId)
                                                .FirstOrDefault();

                                            if (productSectionGroup == null)
                                            {
                                                productSectionGroup = new ProductSectionGroup
                                                {
                                                    Product = product,
                                                    SectionGroup = sectionGroup
                                                };
                                                product.SectionGroups.Add(productSectionGroup);
                                                _dbContext.SaveChanges();
                                            }

                                            //ProductMachine relationship
                                            MachineSectionGroupProduct productMachine = _dbContext
                                                .Set<MachineSectionGroupProduct>()
                                                .Where(pm => pm.ProductId == product.ProductId && pm.MachineId == machine.MachineId)
                                                .FirstOrDefault();

                                            if (productMachine == null)
                                            {
                                                productMachine = new MachineSectionGroupProduct
                                                {
                                                    Product = product,
                                                    SectionGroup = sectionGroup,
                                                    Machine = machine,
                                                };
                                                product.MachineSectionGroups.Add(productMachine);
                                                _dbContext.SaveChanges();
                                            }

                                            //MachineSection relationship
                                            MachineSection machineSection = _dbContext
                                            .Set<MachineSection>()
                                            .Where(m => m.MachineId == machine.MachineId && m.SectionId == section.SectionId)
                                            .FirstOrDefault();

                                            if (machineSection == null)
                                            {
                                                machineSection = new MachineSection
                                                {
                                                    Section = section,
                                                    Machine = machine
                                                };
                                                machine.Sections.Add(machineSection);
                                                _dbContext.SaveChanges();
                                            }

                                            //MachineSectionGroup relationship
                                            MachineSectionGroup machineSectionGroup = _dbContext
                                            .Set<MachineSectionGroup>()
                                            .Where(m => m.MachineId == machine.MachineId && m.SectionGroupId == sectionGroup.SectionGroupId)
                                            .FirstOrDefault();

                                            if (machineSectionGroup == null)
                                            {
                                                machineSectionGroup = new MachineSectionGroup
                                                {
                                                    SectionGroup = sectionGroup,
                                                    Machine = machine
                                                };
                                                machine.SectionGroups.Add(machineSectionGroup);
                                                _dbContext.SaveChanges();
                                            }

                                            //ProductDescription relationship
                                            ProductDescription productDescription = _dbContext
                                                .Set<ProductDescription>()
                                                .Where(pc => pc.ProductId == product.ProductId && pc.DescriptionId == description.DescriptionId)
                                                .FirstOrDefault();

                                            if (productDescription == null)
                                            {
                                                productDescription = new ProductDescription
                                                {
                                                    Product = product,
                                                    Description = description
                                                };
                                                product.Descriptions.Add(productDescription);
                                                _dbContext.SaveChanges();
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                    count++;

                    Console.WriteLine("Ended dbOpration");
                    DateTime endTime = DateTime.Now;
                    TimeSpan cycleTime = endTime - startTime;

                    TimeSpan totalTime = cycleTime * masterLines.Count;
                    TimeSpan remTime = totalTime - (cycleTime * count);

                    Console.WriteLine($"cycleTime: {cycleTime.TotalHours}hours, totalTime: {totalTime.TotalHours}Hours, remaining time: {remTime.TotalHours}Hours");
                }
                _dbContext.SaveChanges();

                Console.WriteLine("End of request");
            }
        }


        private void Save()
        {
            _dbContext.SaveChanges();
        }


        private HashSet<MasterTableLine> SheetToTableLine(ExcelWorksheet workSheet)
        {
            int totalRows = workSheet.Dimension.Rows;

            //new master table line object with properties of excel table columns
            HashSet<MasterTableLine> masterLines = new HashSet<MasterTableLine>();

            string lineSection = null;
            string lineSectionGroup = null;
            string lineModelName = null;
            string lineMachineSerialNumber = null;

            //convert file data to master table line list
            for (int i = 1; i <= totalRows; i++)
            {
                Console.WriteLine("Countering" + i);
                int next = i + 1;


                //check for tha begining of a new section in table
                bool sectionBool = workSheet.Cells[i, 3].Style.Font.Bold;
                bool sectionGroupBool = workSheet.Cells[next, 3].Style.Font.Bold;
                if (sectionBool && sectionGroupBool)
                {
                    lineModelName = workSheet.Cells[i - 1, 1].Value != null ? workSheet.Cells[i - 1, 1].Value.ToString() : lineModelName;
                    lineMachineSerialNumber = workSheet.Cells[i - 1, 2].Value != null ? workSheet.Cells[i - 1, 2].Value.ToString() : lineModelName;
                    lineSection = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : "";
                    lineSectionGroup = workSheet.Cells[next, 3].Value != null ? workSheet.Cells[next, 3].Value.ToString() : "";
                }

                if (sectionBool && !sectionGroupBool)
                {
                    lineSectionGroup = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : "";
                }

                bool containsPart = workSheet.Cells[i, 4].Value != null;

                if (!sectionBool && containsPart)
                {
                    masterLines.Add(new MasterTableLine
                    {
                        ModelName = lineModelName,
                        MachineSerialNumber = lineMachineSerialNumber,
                        Section = lineSection,
                        SectionGroup = lineSectionGroup,
                        Description = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : "",
                        PartNumber = workSheet.Cells[i, 4].Value != null ? workSheet.Cells[i, 4].Value.ToString() : "",
                        Quantity = workSheet.Cells[i, 5].Value != null ? workSheet.Cells[i, 5].Value.ToString() : "",
                        SerialNo = workSheet.Cells[i, 6].Value != null ? workSheet.Cells[i, 6].Value.ToString() : "",
                        Remark = workSheet.Cells[i, 7].Value != null ? workSheet.Cells[i, 7].Value.ToString() : "",
                        Brand = "Komatsu"
                    });
                }
            }

            return masterLines;
        }
    }
}

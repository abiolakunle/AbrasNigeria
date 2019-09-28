using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Services
{
    public class ExcelPartBookToDb
    {
        private readonly AppDbContext _dbContext;
        private readonly IHostingEnvironment _environment;

        public ExcelPartBookToDb(AppDbContext dbContext, IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
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

                //string prevBrand = null;
                //string prevMachine = null;
                //string prevSection = null;
                //string prevSectionGroup = null;
                //string prevCategory = null;
                //string prevProduct = null;
                //string prevQuantity = null;
                //string prevSerial = null;
                //string prevRemark = null;

                //get data to db
                foreach (var line in masterLines)
                {
                    Console.WriteLine("Cycle" + count++);
                    DateTime startTime = DateTime.Now;

                    if (line.Brand != "")
                    {
                        Brand brand = _dbContext.Brands.Where(b => b.Name == line.Brand).FirstOrDefault();

                        if (brand == null)
                        {
                            brand = new Brand
                            {
                                Name = line.Brand
                            };

                            _dbContext.Brands.Add(brand);
                            _dbContext.SaveChanges();
                            Console.WriteLine("Added brand");
                            brand = _dbContext.Brands.Where(b => b.Name == line.Brand).FirstOrDefault();
                        }

                        //Install - Package FlexLabs.EntityFrameworkCore.Upsert - Version 2.1.2
                        //_dbContext.Upsert(brand).On(b => new { b.Name }).Run();

                        if (line.ModelName != "")
                        {
                            Machine machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();

                            if (machine == null)
                            {
                                machine = new Machine
                                {
                                    ModelName = line.ModelName,
                                    SerialNumber = line.MachineSerialNumber,
                                    Brand = brand
                                };
                                _dbContext.Machines.Add(machine);
                                _dbContext.SaveChanges();
                                Console.WriteLine("Added machine");
                                machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();
                            }

                            if (line.Section != "")
                            {
                                Section section = _dbContext.Sections.Where(s => s.SectionName == line.Section).FirstOrDefault();

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
                                        _dbContext.SectionGroups.Where(s => s.SectionGroupName == line.SectionGroup).FirstOrDefault();
                                    }

                                    //_dbContext.SectionGroups.Upsert(sectionGroup).On(s => new { s.SectionGroupName }).Run();

                                    if (line.Description != "")
                                    {
                                        Category category = _dbContext.Categories.Where(c => c.CategoryName == line.Description).FirstOrDefault();

                                        if (category == null)
                                        {
                                            category = new Category
                                            {
                                                CategoryName = line.Description,
                                            };
                                            _dbContext.Categories.Add(category);
                                            _dbContext.SaveChanges();
                                            Console.WriteLine("Added category");
                                            category = _dbContext.Categories.Where(c => c.CategoryName == line.Description).FirstOrDefault();
                                        }

                                        //_dbContext.Categories.Upsert(category).On(s => new { s.CategoryName }).Run();

                                        if (line.PartNumber != "")
                                        {
                                            Product product = _dbContext.Products.Where(p => p.PartNumber == line.PartNumber).FirstOrDefault();

                                            if (product == null)
                                            {
                                                product = new Product
                                                {
                                                    PartNumber = line.PartNumber,
                                                    Brand = brand,
                                                    Section = section,
                                                    Remarks = line.Remark
                                                };
                                                _dbContext.Products.Add(product);
                                                _dbContext.SaveChanges();
                                                Console.WriteLine("Added product");
                                                product = _dbContext.Products.Where(p => p.PartNumber == line.PartNumber).FirstOrDefault();
                                            }

                                            //_dbContext.Products.Upsert(product).On(s => new { s.PartNumber }).Run();

                                            if (line.Quantity != "")
                                            {
                                                Quantity quantity = _dbContext.Quantities.Where(q => q.Value == line.Quantity).FirstOrDefault();

                                                if (quantity == null)
                                                {
                                                    quantity = new Quantity
                                                    {
                                                        Value = line.Quantity
                                                    };
                                                    _dbContext.Quantities.Add(quantity);
                                                    _dbContext.SaveChanges();
                                                    Console.WriteLine("Added quantity");
                                                    quantity = _dbContext.Quantities.Where(q => q.Value == line.Quantity).FirstOrDefault();
                                                }


                                                if (line.SerialNo != "")
                                                {
                                                    SerialNo serialNo = _dbContext.SerialNos.Where(sn => sn.Value == line.SerialNo).FirstOrDefault();

                                                    if (serialNo == null)
                                                    {
                                                        serialNo = new SerialNo
                                                        {
                                                            Value = line.SerialNo
                                                        };
                                                        _dbContext.SerialNos.Add(serialNo);
                                                        _dbContext.SaveChanges();
                                                        Console.WriteLine("Added serialNo");
                                                        serialNo = _dbContext.SerialNos.Where(sn => sn.Value == serialNo.Value).FirstOrDefault();
                                                    }

                                                    brand.Categories.Add(category);
                                                    brand.Machines.Add(machine);
                                                    brand.Products.Add(product);
                                                    brand.SectionGroups.Add(sectionGroup);
                                                    brand.Sections.Add(section);
                                                    section.SectionGroups.Add(sectionGroup);

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
                                                        product.ProductSectionGroups.Add(productSectionGroup);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //ProductMachine relationship
                                                    ProductMachine productMachine = _dbContext
                                                        .Set<ProductMachine>()
                                                        .Where(pm => pm.ProductId == product.ProductId && pm.MachineId == machine.MachineId)
                                                        .FirstOrDefault();

                                                    if (productMachine == null)
                                                    {
                                                        productMachine = new ProductMachine
                                                        {
                                                            Product = product,
                                                            Machine = machine
                                                        };
                                                        product.ProductMachines.Add(productMachine);
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
                                                        machine.MachineSections.Add(machineSection);
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
                                                        machine.MachineSectionGroups.Add(machineSectionGroup);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //ProductCategory relationship
                                                    ProductCategory productCategory = _dbContext
                                                        .Set<ProductCategory>()
                                                        .Where(pc => pc.ProductId == product.ProductId && pc.CategoryId == category.CategoryId)
                                                        .FirstOrDefault();

                                                    if (productCategory == null)
                                                    {
                                                        productCategory = new ProductCategory
                                                        {
                                                            Product = product,
                                                            Category = category
                                                        };
                                                        product.ProductCategories.Add(productCategory);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //MachineProductSectionGroupQuantity relationship
                                                    MachineProductSectionGroupQuantity productQuantity = _dbContext
                                                        .Set<MachineProductSectionGroupQuantity>()
                                                        .Where(pq => pq.ProductId == product.ProductId && pq.MachineId == machine.MachineId && pq.SectionGroupId == sectionGroup.SectionGroupId)
                                                        .FirstOrDefault();

                                                    if (productQuantity == null)
                                                    {
                                                        productQuantity = new MachineProductSectionGroupQuantity
                                                        {
                                                            Product = product,
                                                            Quantity = quantity,
                                                            Machine = machine,
                                                            SectionGroup = sectionGroup
                                                        };
                                                        product.ProductQuantities.Add(productQuantity);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //ProductSectionGroupSerialNo relationship
                                                    ProductSectionGroupSerialNo productSectionGroupSerial = _dbContext
                                                        .Set<ProductSectionGroupSerialNo>()
                                                        .Where(pss => pss.ProductId == product.ProductId && pss.SectionGroupId == sectionGroup.SectionGroupId && pss.MachineId == machine.MachineId)
                                                        .FirstOrDefault();

                                                    if (productSectionGroupSerial == null)
                                                    {
                                                        productSectionGroupSerial = new ProductSectionGroupSerialNo
                                                        {
                                                            Product = product,
                                                            SectionGroup = sectionGroup,
                                                            Machine = machine,
                                                            SerialNo = serialNo
                                                        };
                                                        product.SectionGroupSerialNos.Add(productSectionGroupSerial);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    if (line.Remark != "")
                                                    {
                                                        Remark remark = _dbContext.Remarks.Where(r => r.Value == line.Remark).FirstOrDefault();

                                                        if (remark == null)
                                                        {
                                                            remark = new Remark
                                                            {
                                                                Value = line.Remark
                                                            };
                                                            _dbContext.Remarks.Add(remark);
                                                            _dbContext.SaveChanges();
                                                        }

                                                        Console.WriteLine("Added remark");
                                                        remark = _dbContext.Remarks.Where(r => r.Value == remark.Value).FirstOrDefault();

                                                        //ProductMachineRemark relationship
                                                        ProductMachineRemark productMachineRemark = _dbContext
                                                            .Set<ProductMachineRemark>()
                                                            .Where(pmr => pmr.ProductId == product.ProductId && pmr.MachineId == machine.MachineId)
                                                            .FirstOrDefault();

                                                        if (productMachineRemark == null)
                                                        {
                                                            productMachineRemark = new ProductMachineRemark
                                                            {
                                                                Product = product,
                                                                Machine = machine,
                                                                Remark = remark
                                                            };
                                                            product.ProductMachineRemarks.Add(productMachineRemark);
                                                            _dbContext.SaveChanges();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
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


        public async Task CopyToDbOld(IFormFile masterFile)
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

                //get data to db
                foreach (var line in masterLines)
                {
                    Console.WriteLine("Cycle" + count++);

                    if (line.Brand != "")
                    {
                        Brand brand = new Brand
                        {
                            Name = line.Brand
                        };

                        Brand dbBrand = _dbContext.Brands.Where(b => b.Name == brand.Name).FirstOrDefault();
                        if (dbBrand == null)
                        {
                            _dbContext.Brands.Add(brand);
                            _dbContext.SaveChanges();
                        }
                        //Install - Package FlexLabs.EntityFrameworkCore.Upsert - Version 2.1.2
                        //_dbContext.Upsert(brand).On(b => new { b.Name }).Run();
                        Console.WriteLine("Added brand");
                        brand = _dbContext.Brands.Where(b => b.Name == line.Brand).FirstOrDefault();

                        if (line.ModelName != "")
                        {
                            Machine machine = new Machine
                            {
                                ModelName = line.ModelName,
                                SerialNumber = line.MachineSerialNumber,
                                Brand = brand
                            };

                            Machine dbMachine = _dbContext.Machines.Where(m => m.ModelName == machine.ModelName).FirstOrDefault();

                            if (dbMachine == null)
                            {
                                _dbContext.Machines.Add(machine);
                                _dbContext.SaveChanges();

                            }

                            // _dbContext.Upsert(machine).On(m => new { m.ModelName }).Run();
                            Console.WriteLine("Added machine");
                            machine = _dbContext.Machines.Where(m => m.ModelName == line.ModelName).FirstOrDefault();


                            if (line.Section != "")
                            {
                                Section section = new Section
                                {
                                    SectionName = line.Section
                                };

                                Section dbSection = _dbContext.Sections.Where(s => s.SectionName == section.SectionName).FirstOrDefault();

                                if (dbSection == null)
                                {
                                    _dbContext.Sections.Add(section);
                                    _dbContext.SaveChanges();

                                }

                                //_dbContext.Sections.Upsert(section).On(s => new { s.SectionName }).Run();
                                Console.WriteLine("Added section");
                                section = _dbContext.Sections.Where(s => s.SectionName == line.Section).FirstOrDefault();

                                if (line.SectionGroup != "")
                                {
                                    SectionGroup sectionGroup = new SectionGroup
                                    {
                                        SectionGroupName = line.SectionGroup,
                                        Section = section
                                    };

                                    SectionGroup dbSectionGroup = _dbContext.SectionGroups
                                        .Where(s => s.SectionGroupName == sectionGroup.SectionGroupName)
                                        .FirstOrDefault();

                                    if (dbSectionGroup == null)
                                    {
                                        _dbContext.SectionGroups.Add(sectionGroup);
                                        _dbContext.SaveChanges();

                                    }

                                    //_dbContext.SectionGroups.Upsert(sectionGroup).On(s => new { s.SectionGroupName }).Run();
                                    Console.WriteLine("Added sectiongroup");
                                    sectionGroup = _dbContext.SectionGroups.Where(sg => sg.SectionGroupName == sectionGroup.SectionGroupName).FirstOrDefault();

                                    if (line.Description != "")
                                    {
                                        Category category = new Category
                                        {
                                            CategoryName = line.Description,
                                        };

                                        Category dbCategory = _dbContext.Categories.Where(c => c.CategoryName == category.CategoryName).FirstOrDefault();

                                        if (dbCategory == null)
                                        {
                                            _dbContext.Categories.Add(category);
                                            _dbContext.SaveChanges();

                                        }

                                        //_dbContext.Categories.Upsert(category).On(s => new { s.CategoryName }).Run();
                                        Console.WriteLine("Added category");
                                        category = _dbContext.Categories.Where(s => s.CategoryName == category.CategoryName).FirstOrDefault();

                                        //brand.Categories.Add(category);


                                        if (line.PartNumber != "")
                                        {
                                            Product product = new Product
                                            {
                                                PartNumber = line.PartNumber,
                                                Brand = brand,
                                                //Category = category,
                                                Section = section,
                                                //Quantity = line.Quantity,
                                                Remarks = line.Remark
                                            };

                                            Product dbProduct = _dbContext.Products.Where(p => p.PartNumber == product.PartNumber).FirstOrDefault();

                                            if (dbProduct == null)
                                            {
                                                _dbContext.Products.Add(product);
                                                _dbContext.SaveChanges();
                                            }

                                            //_dbContext.Products.Upsert(product).On(s => new { s.PartNumber }).Run();
                                            Console.WriteLine("Added product");
                                            product = _dbContext.Products.Where(p => p.PartNumber == product.PartNumber).FirstOrDefault();


                                            if (line.Quantity != "")
                                            {
                                                Quantity quantity = new Quantity
                                                {
                                                    Value = line.Quantity
                                                };

                                                Quantity dbQuantity = _dbContext.Quantities.Where(q => q.Value == quantity.Value).FirstOrDefault();

                                                if (dbQuantity == null)
                                                {
                                                    _dbContext.Quantities.Add(quantity);
                                                    _dbContext.SaveChanges();
                                                }

                                                Console.WriteLine("Added quantity");
                                                quantity = _dbContext.Quantities.Where(q => q.Value == quantity.Value).FirstOrDefault();

                                                if (line.SerialNo != "")
                                                {
                                                    SerialNo serialNo = new SerialNo
                                                    {
                                                        Value = line.SerialNo
                                                    };

                                                    SerialNo dbSerialNo = _dbContext.SerialNos.Where(sn => sn.Value == serialNo.Value).FirstOrDefault();

                                                    if (dbSerialNo == null)
                                                    {
                                                        _dbContext.SerialNos.Add(serialNo);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    Console.WriteLine("Added serialNo");
                                                    serialNo = _dbContext.SerialNos.Where(sn => sn.Value == serialNo.Value).FirstOrDefault();


                                                    brand.Categories.Add(category);

                                                    brand.Machines.Add(machine);

                                                    brand.Products.Add(product);

                                                    brand.SectionGroups.Add(sectionGroup);

                                                    brand.Sections.Add(section);

                                                    section.SectionGroups.Add(sectionGroup);

                                                    //category.Products.Add(product);

                                                    _dbContext.SaveChanges();

                                                    //ProductSectionGroup relationship
                                                    ProductSectionGroup productSectionGroup = new ProductSectionGroup
                                                    {
                                                        Product = product,
                                                        SectionGroup = sectionGroup
                                                    };

                                                    ProductSectionGroup dbProductSectionGroup = _dbContext
                                                        .Set<ProductSectionGroup>()
                                                        .Where(psg => psg.SectionGroupId == sectionGroup.SectionGroupId && psg.ProductId == product.ProductId)
                                                        .FirstOrDefault();

                                                    if (dbProductSectionGroup == null)
                                                    {
                                                        product.ProductSectionGroups.Add(productSectionGroup);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //ProductMachine relationship
                                                    ProductMachine productMachine = new ProductMachine
                                                    {
                                                        Product = product,
                                                        Machine = machine
                                                    };

                                                    ProductMachine dbProductMachine = _dbContext
                                                        .Set<ProductMachine>()
                                                        .Where(pm => pm.ProductId == product.ProductId && pm.MachineId == machine.MachineId)
                                                        .FirstOrDefault();

                                                    if (dbProductMachine == null)
                                                    {
                                                        product.ProductMachines.Add(productMachine);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //MachineSection relationship
                                                    MachineSection machineSection = new MachineSection
                                                    {
                                                        Section = section,
                                                        Machine = machine
                                                    };

                                                    MachineSection dbMachineSection = _dbContext
                                                        .Set<MachineSection>()
                                                        .Where(m => m.MachineId == machine.MachineId && m.SectionId == section.SectionId)
                                                        .FirstOrDefault();

                                                    if (dbMachineSection == null)
                                                    {
                                                        machine.MachineSections.Add(machineSection);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //MachineSectionGroup relationship
                                                    MachineSectionGroup machineSectionGroup = new MachineSectionGroup
                                                    {
                                                        SectionGroup = sectionGroup,
                                                        Machine = machine
                                                    };

                                                    MachineSectionGroup dbMachineSectionGroup = _dbContext
                                                        .Set<MachineSectionGroup>()
                                                        .Where(m => m.MachineId == machine.MachineId && m.SectionGroupId == sectionGroup.SectionGroupId)
                                                        .FirstOrDefault();

                                                    if (dbMachineSectionGroup == null)
                                                    {
                                                        machine.MachineSectionGroups.Add(machineSectionGroup);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //ProductCategory relationship
                                                    ProductCategory productCategory = new ProductCategory
                                                    {
                                                        Product = product,
                                                        Category = category
                                                    };

                                                    ProductCategory dbProductCategory = _dbContext
                                                        .Set<ProductCategory>()
                                                        .Where(pc => pc.ProductId == product.ProductId && pc.CategoryId == category.CategoryId)
                                                        .FirstOrDefault();

                                                    if (dbProductCategory == null)
                                                    {
                                                        product.ProductCategories.Add(productCategory);
                                                        _dbContext.SaveChanges();
                                                    }

                                                    //MachineProductSectionGroupQuantity relationship
                                                    MachineProductSectionGroupQuantity productQuantity = new MachineProductSectionGroupQuantity
                                                    {
                                                        Product = product,
                                                        Quantity = quantity,
                                                        Machine = machine,
                                                        SectionGroup = sectionGroup
                                                    };

                                                    MachineProductSectionGroupQuantity dbProductQuantity = _dbContext
                                                        .Set<MachineProductSectionGroupQuantity>()
                                                        .Where(pq => pq.ProductId == product.ProductId && pq.MachineId == machine.MachineId && pq.SectionGroupId == sectionGroup.SectionGroupId)
                                                        .FirstOrDefault();

                                                    if (dbProductQuantity == null)
                                                    {
                                                        product.ProductQuantities.Add(productQuantity);
                                                        _dbContext.SaveChanges();
                                                    }


                                                    //ProductSectionGroupSerialNo relationship
                                                    ProductSectionGroupSerialNo productSectionGroupSerial = new ProductSectionGroupSerialNo
                                                    {
                                                        Product = product,
                                                        SectionGroup = sectionGroup,
                                                        Machine = machine,
                                                        SerialNo = serialNo
                                                    };

                                                    ProductSectionGroupSerialNo dbProductSectionGroupSerial = _dbContext
                                                        .Set<ProductSectionGroupSerialNo>()
                                                        .Where(pss => pss.ProductId == product.ProductId && pss.SectionGroupId == sectionGroup.SectionGroupId && pss.MachineId == machine.MachineId)
                                                        .FirstOrDefault();

                                                    if (dbProductSectionGroupSerial == null)
                                                    {
                                                        product.SectionGroupSerialNos.Add(productSectionGroupSerial);
                                                        _dbContext.SaveChanges();
                                                    }


                                                    if (line.Remark != "")
                                                    {
                                                        Remark remark = new Remark
                                                        {
                                                            Value = line.Remark
                                                        };

                                                        Remark dbRemark = _dbContext.Remarks.Where(r => r.Value == remark.Value).FirstOrDefault();

                                                        if (dbRemark == null)
                                                        {
                                                            _dbContext.Remarks.Add(remark);
                                                            _dbContext.SaveChanges();
                                                        }

                                                        Console.WriteLine("Added remark");
                                                        remark = _dbContext.Remarks.Where(r => r.Value == remark.Value).FirstOrDefault();

                                                        //ProductMachineRemark relationship
                                                        ProductMachineRemark productMachineRemark = new ProductMachineRemark
                                                        {
                                                            Product = product,
                                                            Machine = machine,
                                                            Remark = remark
                                                        };

                                                        ProductMachineRemark dbProductMachineRemark = _dbContext
                                                            .Set<ProductMachineRemark>()
                                                            .Where(pmr => pmr.ProductId == product.ProductId && pmr.MachineId == machine.MachineId)
                                                            .FirstOrDefault();

                                                        if (dbProductMachineRemark == null)
                                                        {
                                                            product.ProductMachineRemarks.Add(productMachineRemark);
                                                            _dbContext.SaveChanges();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("Ended dbOpration");
                }
                _dbContext.SaveChanges();

                Console.WriteLine("End of request");
            }
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

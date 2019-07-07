using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class ExcelToDbController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly AppDbContext _dbContext;

        public ExcelToDbController(IHostingEnvironment environment, AppDbContext dbContext)
        {
            _environment = environment;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> UploadExcel([FromForm]IFormFile masterFile)
        {

            if (masterFile == null || masterFile.Length == 0)
            {
                return Content("File not selected");
            }

            //check if file extension is excel
            string fileExtension = Path.GetExtension(masterFile.FileName);

            //Validate uploaded file and return error
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            {
                //ViewBag.Message = "Please select the excel file with .xls or .xlsx extension";
                //return View();
            }

            //Generate full filpath and save file
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _environment.WebRootPath, "uploads/" + masterFile.FileName);

            using (var bits = new FileStream(filePath, FileMode.Create))
            {
                await masterFile.CopyToAsync(bits);
            }

            FileInfo file = new FileInfo(filePath);

            //Install-Package EPPlus.Core -Version 1.5.4
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
                int totalRows = workSheet.Dimension.Rows;

                HashSet<MasterTableLine> masterLines = new HashSet<MasterTableLine>();

                string lineSection = null;
                string lineSectionGroup = null;
                string modelName = null;

                for (int i = 1; i <= totalRows; i++)
                {
                    Console.WriteLine("Countering" + i);
                    int next = i + 1;




                    bool sectionBool = workSheet.Cells[i, 3].Style.Font.Bold;
                    bool sectionGroupBool = workSheet.Cells[next, 3].Style.Font.Bold;
                    if (sectionBool && sectionGroupBool)
                    {
                        modelName = workSheet.Cells[i - 1, 1].Value != null ? workSheet.Cells[i - 1, 1].Value.ToString() : modelName;
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
                            ModelName = modelName,
                            SerialNumber = workSheet.Cells[i, 6].Value != null ? workSheet.Cells[i, 6].Value.ToString() : "",
                            Section = lineSection,
                            SectionGroup = lineSectionGroup,
                            PartName = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : "",
                            PartNumber = workSheet.Cells[i, 4].Value != null ? workSheet.Cells[i, 4].Value.ToString() : "",
                            Quantity = workSheet.Cells[i, 5].Value != null ? workSheet.Cells[i, 5].Value.ToString() : "",
                            Remarks = workSheet.Cells[i, 7].Value != null ? workSheet.Cells[i, 7].Value.ToString() : "",
                            Brand = "Komatsu"
                        });
                    }


                }


                int count = 0;

                //get data to db
                foreach (var line in masterLines)
                {
                    Console.WriteLine("Cycle" + count++);
                    Console.WriteLine("Started db operation");
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
                                SerialNumber = line.SerialNumber,
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
                                    sectionGroup = _dbContext.SectionGroups.Where(s => s.SectionGroupName == sectionGroup.SectionGroupName).FirstOrDefault();



                                    if (line.PartName != "")
                                    {
                                        Category category = new Category
                                        {
                                            CategoryName = line.PartName,
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

                                        brand.Categories.Add(category);
                                        _dbContext.SaveChanges();

                                        if (line.PartNumber != null)
                                        {
                                            Product product = new Product
                                            {
                                                PartNumber = line.PartNumber,
                                                Brand = brand,
                                                Category = category,
                                                Quantity = line.Quantity,
                                                Remarks = line.Remarks
                                            };

                                            Product dbProduct = _dbContext.Products.Where(p => p.PartNumber == product.PartNumber).FirstOrDefault();

                                            if (dbProduct == null)
                                            {
                                                _dbContext.Products.Add(product);
                                                _dbContext.SaveChanges();
                                            }

                                            //_dbContext.Products.Upsert(product).On(s => new { s.PartNumber }).Run();
                                            Console.WriteLine("Added product");
                                            product = _dbContext.Products.Where(s => s.PartNumber == line.PartNumber).FirstOrDefault();

                                            //Brand One to many
                                            brand.Categories.Add(category);

                                            brand.Machines.Add(machine);

                                            brand.Products.Add(product);

                                            brand.SectionGroups.Add(sectionGroup);

                                            brand.Sections.Add(section);


                                            section.SectionGroups.Add(sectionGroup);

                                            sectionGroup.Products.Add(product);


                                            //Category One to many
                                            category.Products.Add(product);

                                            _dbContext.SaveChanges();

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

                return Ok();
            }
        }
    }
}

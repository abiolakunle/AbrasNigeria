using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;
using System.Threading.Tasks;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Extensions;

namespace AbrasNigeria.Data.Repositories
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MachineDTO>> LoadAllWithBrand()
        {
            //return await _context.Machines.Include(m => m.Brand).ToListAsync();
            return await _context.Machines
                .Include(m => m.Brand)
                .Select(m => new MachineDTO
                {
                    ModelName = m.ModelName,
                    SerialNumber = m.SerialNumber,
                    BrandName = m.Brand.Name,
                    Products = m.ProductMachines.Select(pm => new ProductDTO
                    {
                        PartNumber = pm.Product.PartNumber
                    })
                }).ToListAsync();
        }


        public MachineDTO LoadWithBrandSection(int id)
        {

            //_context.Machines.Where(m => m.MachineId ==id).Select(m => new MachineDTO
            //{
            //    ModelName = m.ModelName,
            //    SerialNumber = m.SerialNumber,
            //    BrandName = m.Brand.Name,
            //    Sections = m.MachineSections.Where(s => s.MachineId == m.MachineId
            //}).Select(m=> m.Products).Where(p => p.)

            return _context.Machines.Where(m => m.MachineId == id).Select(m => new MachineDTO
            {
                ModelName = m.ModelName,
                SerialNumber = m.SerialNumber,
                BrandName = m.Brand.Name,
                Products = m.ProductMachines.Select(pm => new ProductDTO
                {
                    PartNumber = pm.Product.PartNumber,
                    Category = pm.Product.Category.CategoryName
                }),
                Sections = m.MachineSections.Where(s => s.MachineId == m.MachineId).Select(s => new SectionDTO
                {
                    SectionName = s.Section.SectionName,
                    SectionGroups = m.MachineSectionGroups
                    .Where(msg => msg.MachineId == m.MachineId && msg.SectionGroup.Section.SectionId == s.Section.SectionId)
                    .Select(msg => new SectionGroupDTO
                    {
                        SectionGroupName = msg.SectionGroup.SectionGroupName,
                        Section = msg.SectionGroup.Section.SectionName,

                        //this Took me three day to wrap my head around, got solution here https://stackoverflow.com/questions/11285045/intersect-two-lists-with-different-objects/11285117#11285117  Raphaël Althaus
                        //selecting products that are in this productsection which also belong to this machine
                        Products = msg.SectionGroup.ProductSectionGroups.Select(psg => psg.Product)
                        .Where(p => m.ProductMachines.Select(pm => pm.ProductId).Contains(p.ProductId)).Select(pg => new ProductDTO
                        {
                            PartNumber = pg.PartNumber,
                            Category = pg.Category.CategoryName
                        })



                        //Select(psg => psg.Product).Where(p => msg.SectionGroup.ProductSectionGroups.Select(psg => psg.Product.ProductId)
                        //.Intersect(m.ProductMachines.Select(pm => pm.ProductMachineId)
                        //).Contains(p.ProductId)).Select(pm => new ProductDTO
                        //{
                        //    PartNumber = pm.PartNumber,
                        //    Category = pm.Category.CategoryName
                        //})

                        //.Where(psg => psg.SectionGroup.Section.SectionId == s.SectionId)
                        //.Where(psg => psg.Product.ProductMachines.Any(pm => pm.MachineId == pm.MachineId))




                        //.Select(psg => new ProductDTO
                        //{
                        //    PartNumber = psg.Product.PartNumber,
                        //    Category = psg.Product.Category.CategoryName
                        //})

                        //.Join(m.ProductMachines,
                        //        psg => psg.ProductId,
                        //        pm => pm.ProductId,
                        //        (psg, prodG) => new ProductDTO
                        //        {
                        //            PartNumber = psg.Product.PartNumber,
                        //            Category = psg.Product.Category.CategoryName
                        //        })





                        //.Where(psg => psg.SectionGroup.SectionGroupId == msg.SectionGroupId)
                        //.Select(psg => new ProductDTO
                        //{
                        //    PartNumber = psg.Product.PartNumber,
                        //    Category = psg.Product.Category.CategoryName
                        //})

                        //m.ProductMachines
                        //.Where(pm => pm.MachineId == m.MachineId) //&& pm.Product.Section.SectionId == s.SectionId
                        //.Where(pm => pm.Product.ProductSectionGroups.Any(psg => psg.ProductId == pm.ProductId)
                        //)
                        //.Select(pm => new ProductDTO
                        //{
                        //    PartNumber = pm.Product.PartNumber,
                        //    Category = pm.Product.Category.CategoryName
                        //})


                        //m.ProductMachines.Where(pm => pm.MachineId == m.MachineId).Select(p => new ProductDTO
                        //{
                        //    PartNumber = p.Product.PartNumber
                        //})



                    })
                })
            }).FirstOrDefault();


            //return _context.Machines.Where(m => m.MachineId == id).Include(b => b.Brand).ThenInclude(msg => msg.Products)
            //    .Include(m => m.MachineSections)
            //    .ThenInclude(ms => ms.Section)
            //    .Include(m => m.MachineSectionGroups)
            //    .ThenInclude(msg => msg.SectionGroup).FirstOrDefault();

        }
    }
}

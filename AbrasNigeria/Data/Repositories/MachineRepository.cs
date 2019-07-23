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
                .Select(m => new MachineDTO
                {
                    MachineId = m.MachineId,
                    ModelName = m.ModelName,
                    SerialNumber = m.SerialNumber,
                    BrandName = m.Brand.Name,
                }).ToListAsync();
        }


        public MachineDTO LoadWithBrandSection(int id)
        {
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
                    })
                })
            }).FirstOrDefault();


        }

        public IEnumerable<MachineDTO> Search(string searchQuery)
        {
            return _context.Machines
                 .Where(m => m.MachineSectionGroups
                 .Contains(m.MachineSectionGroups.Where(ms => ms.Machine.ModelName.Contains(searchQuery)).FirstOrDefault()))
                 .Select(m => new MachineDTO
                 {
                     BrandName = m.Brand.Name,
                     ModelName = m.ModelName,
                     SerialNumber = m.SerialNumber,
                 });
        }
    }
}

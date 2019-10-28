using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;

namespace AbrasNigeria.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(PartsBookDbContext context) : base(context) { }

        public IEnumerable<Product> Filter(FilterProductsDTO filter)
        {
            return _table
                .Include(p => p.Descriptions).ThenInclude(d => d.Description)
                .Where(p => p.Brand.Name.Contains(filter.Brand))
                .Where(p => p.Descriptions.Contains(p.Descriptions.Where(pc => pc.Description.DescriptionName.Contains(filter.Description)).FirstOrDefault()))
                .Where(p => p.PartNumber.Contains(filter.PartNumber))
                .Where(p => p.Section.SectionName.Contains(filter.Section))
                .Where(p => p.SectionGroups.Contains(p.SectionGroups.Where(psg => psg.SectionGroup.SectionGroupName.Contains(filter.SectionGroup)).FirstOrDefault()))
                .Where(p => p.MachineSectionGroups.Contains(p.MachineSectionGroups.Where(pm => pm.Machine.ModelName.Contains(filter.Machine)).FirstOrDefault()));
        }


        public Product FindByPartNumber(string partNumber)
        {
            return _table
                .Include(p => p.Brand)
                .Include(p => p.Descriptions).ThenInclude(d => d.Description)
                .Include(p => p.SectionGroups).ThenInclude(sg => sg.SectionGroup)
                .Include(p => p.MachineSectionGroups).ThenInclude(msg => msg.Machine)
                .Where(p => p.PartNumber == partNumber)
                .FirstOrDefault();
        }

        public IEnumerable<Product> Search(string searchQuery)
        {
            return _table
                .Include(p => p.Descriptions).ThenInclude(d => d.Description)
                .Where(p => p.PartNumber.Contains(searchQuery));
        }
    }
}

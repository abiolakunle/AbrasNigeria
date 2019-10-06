using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class DescriptionRepository : Repository<Description>, IDescriptionRepository
    {
        public DescriptionRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Description> LoadAllWithProducts()
        {
            return _context.Descriptions.Include(c => c.ProductDescriptions);
        }

        public IEnumerable<DescriptionDTO> Search(string searchQuery)
        {
            return _context.Descriptions
                .Where(c => c.DescriptionName
                .Contains(searchQuery))
                .Select(c => new DescriptionDTO
                {
                    DescriptionName = c.DescriptionName
                });
        }
    }
}

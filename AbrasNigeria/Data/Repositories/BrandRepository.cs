using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<BrandDTO> Search(string searchQuery)
        {
            return _context.Brands
                .Where(b => b.Name.Contains(searchQuery))
                .Select(b => new BrandDTO
                {
                    BrandName = b.Name
                });
        }
    }
}

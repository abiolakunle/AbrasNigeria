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
        public DescriptionRepository(PartsBookDbContext context) : base(context)
        {

        }

        public IEnumerable<Description> LoadAllWithProducts()
        {
            return _table.Include(c => c.Products);
        }

        public IEnumerable<DescriptionDTO> Search(string searchQuery)
        {
            return _table
                .Where(c => c.DescriptionName
                .Contains(searchQuery))
                .Select(c => new DescriptionDTO
                {
                    DescriptionName = c.DescriptionName
                });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;

namespace AbrasNigeria.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Category> loadAllWithProducts()
        {
           return _context.Categories.Include(c => c.Products);
        }
    }
}

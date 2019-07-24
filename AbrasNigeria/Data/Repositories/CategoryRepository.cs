using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;
using System.Linq;

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

        public IEnumerable<CategoryDTO> Search(string searchQuery)
        {
            return _context.Categories
                .Where(c => c.CategoryName
                .Contains(searchQuery))
                .Select(c => new CategoryDTO
                {
                    CategoryName = c.CategoryName
                });
        }
    }
}

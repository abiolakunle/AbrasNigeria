using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> FindWithCategoryAndBrand(Func<Product, bool> predicate)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Brand).Where(predicate);
        }      

        public async Task<IEnumerable<Product>> LoadAllWithCategoryAndBrand()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Section).ToListAsync();
        }

        public IEnumerable<Product> LoadBySection(Section section)
        {
            return _context.Products.Where(p => p.Section.SectionId == section.SectionId);
        }

        public IEnumerable<Product> LoadWithCategorySectionGroup()
        {
            return _context.Products.Include(p => p.SectionGroup).Include(p => p.Category);
        }

        public IEnumerable<Product> SearchWithCategory(string searchQuery)
        {
            return _context.Products.Where(p => p.PartNumber.Contains(searchQuery)).Include(p => p.Category);
        }
    }
}

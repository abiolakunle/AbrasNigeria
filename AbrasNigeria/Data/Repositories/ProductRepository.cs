using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;
using System.Threading.Tasks;
using AbrasNigeria.Data.DTO;

namespace AbrasNigeria.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> Filter(FilterQueryDTO query)
        {
            return _context.Products
                .Where(p => p.Category.CategoryName.Contains(query.Category))
                .Where(p => p.PartNumber.Contains(query.PartNumber)).Include(p => p.Category);
        }

        public IEnumerable<Product> FindWithCategoryAndBrand(Func<Product, bool> predicate)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Brand).Where(predicate);
        }

        public IEnumerable<Product> LoadAllWithCategoryAndBrand()
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Section);
        }

        public IEnumerable<Product> LoadBySection(Section section)
        {
            return _context.Products.Where(p => p.Section.SectionId == section.SectionId);
        }

        public IEnumerable<Product> LoadWithCategorySectionGroup()
        {
            return _context.Products
                //.Include(p => p.SectionGroup)
                .Include(p => p.Category);
        }

        public IEnumerable<Product> SearchWithCategory(string searchQuery)
        {
            return _context.Products.Where(p => p.PartNumber.Contains(searchQuery)).Include(p => p.Category);
        }
    }
}

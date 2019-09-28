using System;
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
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<ProductDTO> Filter(FilterProductsDTO filter)
        {
            return _context.Products
                .Where(p => p.Brand.Name.Contains(filter.Brand))
                .Where(p => p.ProductCategories.Contains(p.ProductCategories.Where(pc => pc.Category.CategoryName.Contains(filter.Category)).FirstOrDefault()))
                .Where(p => p.PartNumber.Contains(filter.PartNumber))
                .Where(p => p.Section.SectionName.Contains(filter.Section))
                .Where(p => p.ProductSectionGroups.Contains(p.ProductSectionGroups.Where(psg => psg.SectionGroup.SectionGroupName.Contains(filter.SectionGroup)).FirstOrDefault()))
                .Where(p => p.ProductMachines.Contains(p.ProductMachines.Where(pm => pm.Machine.ModelName.Contains(filter.Machine)).FirstOrDefault()))
                //.Include(p => p.Category)
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    PartNumber = p.PartNumber,
                    Categories = p.ProductCategories.Select(pcs => new CategoryDTO
                    {
                        CategoryName = pcs.Category.CategoryName
                    })
                });
        }

        public ProductDTO FindWithProp(int productId)
        {
            return _context.Products
                .Where(p => p.ProductId == productId)
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    PartNumber = p.PartNumber,
                    Categories = p.ProductCategories.Select(pc => new CategoryDTO
                    {
                        CategoryName = pc.Category.CategoryName
                    }),
                    Brand = p.Brand.Name,
                    Section = p.Section.SectionName,

                    Machines = p.ProductMachines
                    .Where(pm => pm.Product.ProductMachines
                    .Contains(p.ProductMachines.Where(pd => pd.ProductId == p.ProductId).FirstOrDefault()))
                    .Select(m => new MachineDTO
                    {
                        ModelName = m.Machine.ModelName
                    }),

                    SectionGroups = p.ProductSectionGroups
                    .Where(psg => psg.Product.ProductSectionGroups
                    .Contains(p.ProductSectionGroups.Where(_psg => _psg.ProductId == p.ProductId).FirstOrDefault()))
                    .Select(sg => new SectionGroupDTO
                    {
                        SectionGroupName = sg.SectionGroup.SectionGroupName,
                    })
                }).FirstOrDefault();
        }

        public IEnumerable<ProductDTO> Search(string searchQuery)
        {
            return _context.Products
                .Where(p => p.PartNumber.Contains(searchQuery))
                .Select(p => new ProductDTO
                {
                    PartNumber = p.PartNumber,
                    Categories = p.ProductCategories.Select(pc => new CategoryDTO
                    {
                        CategoryName = pc.Category.CategoryName
                    }),
                    Brand = p.Brand.Name
                });
        }
    }
}

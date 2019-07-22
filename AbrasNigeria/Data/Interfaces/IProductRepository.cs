using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> LoadAllWithCategoryAndBrand();

        IEnumerable<Product> FindWithCategoryAndBrand(Func<Product, bool> predicate);

        IEnumerable<Product> SearchWithCategory(string searchQuery);

        IEnumerable<Product> LoadWithCategorySectionGroup();

        IEnumerable<Product> Filter(FilterProductsDTO query);


    }
}

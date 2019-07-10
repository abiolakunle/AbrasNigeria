using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> LoadAllWithCategoryAndBrand();

        IEnumerable<Product> FindWithCategoryAndBrand(Func<Product, bool> predicate);

        IEnumerable<Product> SearchWithCategory(string searchQuery);

        IEnumerable<Product> LoadWithCategorySectionGroup();


    }
}

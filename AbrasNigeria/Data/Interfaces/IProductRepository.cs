using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Search(string searchQuery);

        IEnumerable<Product> Filter(FilterProductsDTO query);

        Product FindByPartNumber(string partNumber);
    }
}

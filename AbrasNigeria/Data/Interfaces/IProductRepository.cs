using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        ProductDTO FindWithProp(int productId);

        IEnumerable<ProductDTO> Search(string searchQuery);

        IEnumerable<ProductDTO> Filter(FilterProductsDTO query);


    }
}

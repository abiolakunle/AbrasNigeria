using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Extensions;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.Models;
using AbrasNigeria.Data.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        [HttpGet("[action]")]
        public JsonResult Product(string partNumber)
        {
            ProductDTO product = _productRepository.FindByPartNumber(partNumber).ToDTO();

            return Json(product, JsonHelper.SerializerSettings);
            //return Json(products);
        }

        [HttpGet("[action]")]
        public JsonResult Search(string searchQuery)
        {
            IEnumerable<ProductDTO> products;

            if (searchQuery.Length == 0)
                products = Enumerable.Empty<ProductDTO>();
            else
                products = _productRepository.Search(searchQuery).ToDTO();

            return Json(products, JsonHelper.SerializerSettings);
        }

        [HttpPost("[action]")]
        public JsonResult Filter([FromBody]FilterProductsDTO data)
        {
            IEnumerable<ProductDTO> products = _productRepository.Filter(data).ToDTO();

            PagingInfo pagingInfo = new PagingInfo
            {
                TotalItems = products.Count(),
                CurrentPage = data.Page
            };

            products = products
                .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.ItemsPerPage)
                .Take(pagingInfo.ItemsPerPage);

            HttpContext.Response.Headers.Add("Paging", JsonConvert.SerializeObject(pagingInfo));

            return Json(products, JsonHelper.SerializerSettings);
        }


    }
}


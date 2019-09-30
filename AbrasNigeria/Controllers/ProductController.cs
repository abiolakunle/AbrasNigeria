using AbrasNigeria.Data.DTO;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet("[action]")]
        public JsonResult Product(int productId)
        {
            ProductDTO products = _productRepository.FindWithProp(productId);

            return Json(products, JsonHelper.SerializerSettings);
            //return Json(products);
        }

        [HttpGet("[action]")]
        public JsonResult Search(string searchQuery)
        {
            var products = _productRepository.Search(searchQuery);

            return Json(products, JsonHelper.SerializerSettings);
        }

        [HttpPost("[action]")]
        public JsonResult Filter([FromBody]FilterProductsDTO data)
        {
            IEnumerable<ProductDTO> products = _productRepository.Filter(data);

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


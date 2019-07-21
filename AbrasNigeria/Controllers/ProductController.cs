using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.Utils;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
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
        public JsonResult List()
        {
            var products = _productRepository.LoadAllWithCategoryAndBrand();

            return Json(products, JsonHelper.SerializerSettings);
            //return Json(products);
        }

        [HttpGet("[action]")]
        public JsonResult Search(string searchQuery)
        {
            var products = _productRepository.SearchWithCategory(searchQuery);

            return Json(products, JsonHelper.SerializerSettings);
        }

        [HttpPost("[action]")]
        public JsonResult Filter([FromBody]FilterQueryDTO data)
        {
            IEnumerable<Product> products = _productRepository.Filter(data);

            return Json(products, JsonHelper.SerializerSettings);
        }
    }
}


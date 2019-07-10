using AbrasNigeria.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<JsonResult> List()
        {
            var products = await _productRepository.LoadAllWithCategoryAndBrand();

            return Json(products, new JsonSerializerSettings()
            {
                NullValueHandling = true ? NullValueHandling.Ignore : NullValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
           //return Json(products);
        }

        [HttpGet("[action]")]
        public JsonResult Search(string searchQuery)
        {
            var products = _productRepository.SearchWithCategory(searchQuery);

            return Json(products, new JsonSerializerSettings()
            {
                NullValueHandling = true ? NullValueHandling.Ignore : NullValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}


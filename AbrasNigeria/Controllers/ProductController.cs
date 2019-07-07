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
        public async Task<IActionResult> List()
        {
            var products = await _productRepository.LoadAllWithCategoryAndBrand();

            //return new Json(products, new JsonSerializerSettings()
            //{
            //    NullValueHandling = true ? NullValueHandling.Ignore : NullValueHandling.Include,
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            return Json(products);
        }
    }
}


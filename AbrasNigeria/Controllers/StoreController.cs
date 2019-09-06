using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.Utils;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class StoreController : Controller
    {

        private readonly IStoreProductRepository _storeProductRepository;

        public StoreController(IStoreProductRepository storeProductRepository)
        {
            _storeProductRepository = storeProductRepository;
        }

        public IActionResult AddProduct([FromBody] StoreProduct storeProduct)
        {
            _storeProductRepository.Create(storeProduct);
            return Ok();
        }

        public JsonResult StoreProducts()
        {
            IEnumerable<StoreProduct> products = _storeProductRepository.GetAll();

            return Json(products, JsonHelper.SerializerSettings);
        }

        public JsonResult StoreProduct(int id)
        {
            StoreProduct product = _storeProductRepository.GetById(id);

            return Json(product, JsonHelper.SerializerSettings);
        }

    }
}

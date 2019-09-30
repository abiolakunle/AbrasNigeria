using AbrasNigeria.Data.DTO;
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
    public class StockController : Controller
    {

        private readonly IStockProductRepository _stockProductRepository;

        public StockController(IStockProductRepository storeProductRepository)
        {
            _stockProductRepository = storeProductRepository;
        }

        [HttpPost("[action]")]
        public ActionResult CreateProduct([FromBody] StockProduct storeProduct)
        {
            _stockProductRepository.Create(storeProduct);
            return Ok();
        }

        [HttpGet("[action]")]
        public JsonResult Products()
        {
            IEnumerable<StockProductDTO> products = _stockProductRepository.LoadAllWithHistory();

            return Json(products, JsonHelper.SerializerSettings);
        }

        [HttpGet("[action]")]
        public JsonResult Product(int id)
        {
            StockProduct product = _stockProductRepository.LoadWithHistory(id);

            return Json(product, JsonHelper.SerializerSettings);
        }

        [HttpPost("[action]")]
        public ActionResult AddHistory([FromBody] StockProductHistory productHistory)
        {

            StockProduct product = _stockProductRepository
                .Find(p => p.StockProductId == productHistory.StockProductId)
                .FirstOrDefault();

            product.StockProductHistories.Add(productHistory);

            _stockProductRepository.Update(product);

            return Ok();
        }

    }
}

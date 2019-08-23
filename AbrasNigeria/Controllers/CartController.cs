using AbrasNigeria.Data.Utils;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private SessionCart _cart;

        public CartController(SessionCart cart)
        {
            _cart = cart;
        }

        [HttpPost("[action]")]
        public ActionResult UpdateCart([FromBody]List<CartItem> cartItems)
        {
            _cart.UpdateCart(cartItems);

            return Ok();
        }

        [HttpGet("[action]")]
        public JsonResult GetCart()
        {
            IEnumerable<CartItem> cartItems = _cart.GetCart();

            return Json(cartItems, JsonHelper.SerializerSettings);
        }

    }
}

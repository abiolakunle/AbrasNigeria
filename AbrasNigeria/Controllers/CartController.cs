using AbrasNigeria.Data.Utils;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Controllers
{
    public class CartController : Controller
    {
        private SessionCart _cart;

        public CartController(SessionCart cart)
        {
            _cart = cart;
        }

        public ActionResult UpdateCart([FromBody]List<CartItem> cartItems)
        {
            _cart.UpdateCart(cartItems);

            return Ok();
        }

        public JsonResult Cart()
        {
            IEnumerable<CartItem> cartItems = _cart.GetCart();

            return Json(cartItems, JsonHelper.SerializerSettings);
        }
    }
}

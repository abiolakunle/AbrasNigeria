using AbrasNigeria.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using AbrasNigeria.Data.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace AbrasNigeria.Data.Utils
{
    public class SessionCart
    {
        public SessionCart(IServiceProvider services)
        {
            Session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
        }

        public IEnumerable<CartItem> GetCart()
        {
            return Session?.GetJson<CartItem>("Cart")
             ?? new List<CartItem>();
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public void UpdateCart(List<CartItem> cartItems)
        {
            Session.SetJson<CartItem>("Cart", cartItems);
        }

        public void Clear()
        {
            Session.Remove("Cart");
        }
    }
}

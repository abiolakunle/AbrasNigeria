using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Utils
{
    public class Cart
    {
        private List<CartItem> _cartItems { get; set; } = new List<CartItem>();

        public virtual void UpdateCart(List<CartItem> cartItems)
        {
            _cartItems = cartItems;
        }

        //public virtual void Clear() => lineCollection.Clear();

    }

}


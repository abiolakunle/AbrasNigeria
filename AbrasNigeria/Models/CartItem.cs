using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Categories = new HashSet<Category>();
        }
        public int CartItemId { get; set; }

        public int ProductId { get; set; }

        public string PartNumber { get; set; }

        public ICollection<Category> Categories { get; set; }

        public int Quantity { get; set; }
    }
}

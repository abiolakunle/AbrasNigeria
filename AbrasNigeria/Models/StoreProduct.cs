using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class StoreProduct
    {
        public int StoreProductId { get; set; }

        public string PartNumber { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public string CurrentQuantity { get; set; }

    }
}

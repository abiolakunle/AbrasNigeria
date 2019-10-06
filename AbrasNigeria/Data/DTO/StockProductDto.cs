using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class StockProductDTO
    {
        public int StockProductId { get; set; }

        public string PartNumber { get; set; }

        public string Descriptions { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Detail { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public int Quantity { get; set; }
    }
}

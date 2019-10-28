using AbrasNigeria.Models;
using System.Collections.Generic;

namespace AbrasNigeria.Data.DTO
{
    public class StockProductDTO
    {
        public long StockProductId { get; set; }

        public string PartNumber { get; set; }

        public string Descriptions { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Detail { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public IEnumerable<StockProductHistory> StockProductHistories { get; set; }
    }
}

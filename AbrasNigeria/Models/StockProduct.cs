using System.Collections.Generic;

namespace AbrasNigeria.Models
{
    public class StockProduct
    {
        public StockProduct()
        {
            Histories = new HashSet<StockProductHistory>();
        }

        public long StockProductId { get; set; }

        public string PartNumber { get; set; }

        public string Descriptions { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string Detail { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public ICollection<StockProductHistory> Histories { get; set; }
    }
}

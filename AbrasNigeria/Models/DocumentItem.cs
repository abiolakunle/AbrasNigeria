namespace AbrasNigeria.Models
{
    public class DocumentItem
    {
        public long DocumentItemId { get; set; }

        public long DocumentId { get; set; }

        public string PartNumber { get; set; }

        public string Descriptions { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}

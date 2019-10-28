namespace AbrasNigeria.Models
{
    public class CartItem
    {
        public CartItem() { }

        public long CartItemId { get; set; }

        public long ProductId { get; set; }

        public string PartNumber { get; set; }

        public string Descriptions { get; set; }

        public int Quantity { get; set; }
    }
}

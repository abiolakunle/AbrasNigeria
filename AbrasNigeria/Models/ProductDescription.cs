namespace AbrasNigeria.Models
{
    public class ProductDescription
    {
        public long ProductDescriptionId { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long DescriptionId { get; set; }
        public Description Description { get; set; }
    }
}

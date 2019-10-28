namespace AbrasNigeria.Models
{
    public class ProductSectionGroup
    {
        public long ProductSectionGroupId { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long SectionGroupId { get; set; }
        public SectionGroup SectionGroup { get; set; }
    }
}

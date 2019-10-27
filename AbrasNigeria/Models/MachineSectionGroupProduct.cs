namespace AbrasNigeria.Models
{
    public class MachineSectionGroupProduct
    {
        public long MachineSectionGroupProductId { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long MachineId { get; set; }
        public Machine Machine { get; set; }

        public long SectionGroupId { get; set; }
        public SectionGroup SectionGroup { get; set; }
    }
}

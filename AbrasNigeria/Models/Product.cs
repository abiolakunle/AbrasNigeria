using System.Collections.Generic;

namespace AbrasNigeria.Models
{
    public class Product
    {
        public Product()
        {
            MachineSectionGroups = new HashSet<MachineSectionGroupProduct>();
            SectionGroups = new HashSet<ProductSectionGroup>();
            Descriptions = new HashSet<ProductDescription>();
        }

        public long ProductId { get; set; }

        public string PartNumber { get; set; }

        public long BrandId { get; set; }
        public Brand Brand { get; set; }

        public long SectionId { get; set; }
        public Section Section { get; set; }

        public ICollection<MachineSectionGroupProduct> MachineSectionGroups { get; set; }

        public ICollection<ProductDescription> Descriptions { get; set; }

        public ICollection<ProductSectionGroup> SectionGroups { get; set; }
    }
}

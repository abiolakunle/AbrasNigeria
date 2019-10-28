using System.Collections.Generic;

namespace AbrasNigeria.Models
{
    public class SectionGroup
    {
        public SectionGroup()
        {

            Machines = new HashSet<MachineSectionGroup>();
            Products = new HashSet<ProductSectionGroup>();
        }

        public long SectionGroupId { get; set; }

        public string SectionGroupName { get; set; }

        public Section Section { get; set; }

        public ICollection<MachineSectionGroup> Machines { get; set; }

        public ICollection<ProductSectionGroup> Products { get; set; }
    }
}

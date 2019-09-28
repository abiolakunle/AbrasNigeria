using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class SectionGroup
    {
        public SectionGroup()
        {

            MachineSectionGroups = new HashSet<MachineSectionGroup>();
            ProductSectionGroups = new HashSet<ProductSectionGroup>();
            //ProductQuantities = new HashSet<MachineProductSectionGroupQuantity>();
        }

        public int SectionGroupId { get; set; }

        public string SectionGroupName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public Section Section { get; set; }

        //public ICollection<MachineProductSectionGroupQuantity> ProductQuantities { get; set; }

        public ICollection<MachineSectionGroup> MachineSectionGroups { get; set; }

        public ICollection<ProductSectionGroup> ProductSectionGroups { get; set; }



    }
}

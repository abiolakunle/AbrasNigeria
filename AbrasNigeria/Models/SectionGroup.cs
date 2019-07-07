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
            Products = new HashSet<Product>();
            MachineSectionGroups = new HashSet<MachineSectionGroup>();
        }

        public int SectionGroupId { get; set; }

        public string SectionGroupName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public virtual Section Section { get; set; }

        //public virtual Machine Machine { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ICollection<MachineSectionGroup> MachineSectionGroups { get; set; }

        

    }
}

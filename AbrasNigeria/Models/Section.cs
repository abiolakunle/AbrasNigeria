using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class Section
    {
        public Section()
        {
            SectionGroups = new HashSet<SectionGroup>();
            MachineSections = new HashSet<MachineSection>();
            MachineSectionGroups = new HashSet<MachineSectionGroup>();
        }

        public int SectionId { get; set; }

        public string SectionName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public ICollection<SectionGroup> SectionGroups { get; set; }

        public ICollection<MachineSection> MachineSections { get; set; }

        public ICollection<MachineSectionGroup> MachineSectionGroups { get; set; }

    }
}

using System.Collections.Generic;

namespace AbrasNigeria.Models
{
    public class Section
    {
        public Section()
        {
            SectionGroups = new HashSet<SectionGroup>();
            Sections = new HashSet<MachineSection>();
            Machines = new HashSet<MachineSectionGroup>();
        }

        public long SectionId { get; set; }

        public string SectionName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public ICollection<SectionGroup> SectionGroups { get; set; }

        public ICollection<MachineSection> Sections { get; set; }

        public ICollection<MachineSectionGroup> Machines { get; set; }

    }
}

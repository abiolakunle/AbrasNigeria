using System.Collections.Generic;

namespace AbrasNigeria.Models
{
    public class Machine
    {
        public Machine()
        {
            SectionGroupProducts = new HashSet<MachineSectionGroupProduct>();
            Sections = new HashSet<MachineSection>();
            SectionGroups = new HashSet<MachineSectionGroup>();
        }

        public long MachineId { get; set; }

        public string ModelName { get; set; }

        public string SerialNumber { get; set; }

        public Brand Brand { get; set; }

        public ICollection<MachineSectionGroupProduct> SectionGroupProducts { get; set; }

        public ICollection<MachineSection> Sections { get; set; }

        public ICollection<MachineSectionGroup> SectionGroups { get; set; }
    }
}

namespace AbrasNigeria.Models
{
    public class MachineSectionGroup
    {
        public long MachineSectionGroupId { get; set; }

        public Machine Machine { get; set; }
        public long MachineId { get; set; }

        public SectionGroup SectionGroup { get; set; }
        public long SectionGroupId { get; set; }
    }
}

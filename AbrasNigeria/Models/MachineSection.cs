namespace AbrasNigeria.Models
{
    public class MachineSection
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long MachineSectionId { get; set; }

        public long MachineId { get; set; }
        public Machine Machine { get; set; }

        public long SectionId { get; set; }
        public Section Section { get; set; }
    }
}

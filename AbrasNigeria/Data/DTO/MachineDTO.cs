using System.Collections.Generic;

namespace AbrasNigeria.Data.DTO
{
    public class MachineDTO
    {
        public long MachineId { get; set; }

        public string ModelName { get; set; }

        public string SerialNumber { get; set; }

        public string BrandName { get; set; }

        public IEnumerable<SectionDTO> Sections { get; set; }
    }
}

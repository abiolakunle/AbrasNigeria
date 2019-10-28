using System.Collections.Generic;

namespace AbrasNigeria.Data.DTO
{
    public class SectionDTO
    {
        public long SectionId { get; set; }

        public string SectionName { get; set; }

        public IEnumerable<SectionGroupDTO> SectionGroups { get; set; }
    }
}

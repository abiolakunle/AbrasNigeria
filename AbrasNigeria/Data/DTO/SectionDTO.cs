using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class SectionDTO
    {
        public string SectionName { get; set; }

        public IEnumerable<SectionGroupDTO> SectionGroups { get; set; }
    }
}

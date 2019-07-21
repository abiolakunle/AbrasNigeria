using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class MachineDTO
    {
        public int MachineId { get; set; }

        public string ModelName { get; set; }

        public string SerialNumber { get; set; }

        public string BrandName { get; set; }

        public IEnumerable<SectionDTO> Sections { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string PartNumber { get; set; }

        public string Brand { get; set; }

        public string Section { get; set; }

        public string Quantity { get; set; }

        public string SerialNo { get; set; }

        public string Remark { get; set; }

        public IEnumerable<MachineDTO> Machines { get; set; }

        public IEnumerable<DescriptionDTO> Descriptions { get; set; }

        public IEnumerable<SectionGroupDTO> SectionGroups { get; set; }

    }
}

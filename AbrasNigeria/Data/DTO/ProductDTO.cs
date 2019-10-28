using System.Collections.Generic;

namespace AbrasNigeria.Data.DTO
{
    public class ProductDTO
    {
        public long ProductId { get; set; }

        public string PartNumber { get; set; }

        public string Brand { get; set; }

        public string Section { get; set; }

        public IEnumerable<MachineDTO> Machines { get; set; }

        public IEnumerable<DescriptionDTO> Descriptions { get; set; }

        public IEnumerable<SectionGroupDTO> SectionGroups { get; set; }

    }
}

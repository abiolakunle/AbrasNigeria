using System.Collections.Generic;

namespace AbrasNigeria.Data.DTO
{
    public class SectionGroupDTO
    {
        public long SectionGroupId { get; set; }

        public string SectionGroupName { get; set; }

        public string Section { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}

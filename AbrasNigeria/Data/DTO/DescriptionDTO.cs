using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class DescriptionDTO
    {
        public string DescriptionName { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}

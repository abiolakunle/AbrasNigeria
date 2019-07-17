using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class SectionGroupDTO
    {
        public string SectionGroupName { get; set; }

        public string Section { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}

using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class FilterQueryDTO
    {
        public string PartNumber { get; set; }

        public string Category { get; set; }

        public string Section { get; set; }

        public string SectionGroup { get; set; }

        public string Machine { get; set; }

        public ProductSectionGroup ProductSectionGroup { get; set; }
    }
}

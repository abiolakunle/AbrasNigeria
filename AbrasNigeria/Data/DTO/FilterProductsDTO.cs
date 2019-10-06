using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class FilterProductsDTO
    {
        public string PartNumber { get; set; }

        public string Description { get; set; }

        public string Section { get; set; }

        public string SectionGroup { get; set; }

        public string Machine { get; set; }

        public string Brand { get; set; }

        public int Page { get; set; }

    }
}

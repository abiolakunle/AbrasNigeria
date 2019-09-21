using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class DocumentItemDTO
    {
        public string PartNumber { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}

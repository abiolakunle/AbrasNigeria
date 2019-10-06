using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class DocumentItem
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public string PartNumber { get; set; }

        public string Descriptions { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}

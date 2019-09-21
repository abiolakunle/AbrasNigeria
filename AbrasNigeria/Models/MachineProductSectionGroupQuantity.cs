using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class MachineProductSectionGroupQuantity
    {

        public int ProductQuantityId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int QuantityId { get; set; }
        public Quantity Quantity { get; set; }

        public int SectionGroupId { get; set; }
        public SectionGroup SectionGroup { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}

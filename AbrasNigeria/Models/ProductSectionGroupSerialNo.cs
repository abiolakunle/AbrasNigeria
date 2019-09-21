using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class ProductSectionGroupSerialNo
    {
        public int ProductSectionGroupSerialNoId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SectionGroupId { get; set; }
        public SectionGroup SectionGroup { get; set; }

        public int SerialNoId { get; set; }
        public SerialNo SerialNo { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}

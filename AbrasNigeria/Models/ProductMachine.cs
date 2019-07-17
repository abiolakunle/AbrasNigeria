using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class ProductMachine
    {
        public int ProductMachineId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}

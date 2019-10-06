using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class ProductDescription
    {
        public int ProductDescriptionId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DescriptionId { get; set; }
        public Description Description { get; set; }
    }
}

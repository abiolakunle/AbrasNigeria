using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class ProductSectionGroup
    {
        public int ProductSectionGroupId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SectionGroupId { get; set; }
        public SectionGroup SectionGroup { get; set; }
    }
}

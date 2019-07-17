

using System.Collections;
using System.Collections.Generic;

namespace AbrasNigeria.Models
{
    public class Product
    {
        public Product()
        {
            ProductMachines = new HashSet<ProductMachine>();
            ProductSectionGroups = new HashSet<ProductSectionGroup>();
        }

        public int ProductId { get; set; }

        public string PartNumber { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public string Quantity { get; set; }

        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }

        public string Remarks { get; set; }

        //public virtual SectionGroup SectionGroup { get; set; }

        public virtual Section Section { get; set; }

        public ICollection<ProductMachine> ProductMachines { get; set; }

        public ICollection<ProductSectionGroup> ProductSectionGroups { get; set; }
    }
}

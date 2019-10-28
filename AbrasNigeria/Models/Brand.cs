using System.Collections.Generic;

namespace AbrasNigeria.Models
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
            Machines = new HashSet<Machine>();
        }

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long BrandId { get; set; }

        //[JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Machine> Machines { get; set; }

    }
}

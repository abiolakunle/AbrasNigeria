using Newtonsoft.Json;
using System.Collections.Generic;


namespace AbrasNigeria.Models
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
            Machines = new HashSet<Machine>();
            Sections = new HashSet<Section>();
            SectionGroups = new HashSet<SectionGroup>();
        }

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        //[JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Machine> Machines { get; set; }

        public ICollection<Section> Sections { get; set; }

        public ICollection<SectionGroup> SectionGroups { get; set; }
    }
}

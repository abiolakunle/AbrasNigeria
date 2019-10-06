using System.Collections.Generic;


namespace AbrasNigeria.Models
{
    public class Description
    {
        public Description()
        {
            ProductDescriptions = new HashSet<ProductDescription>();
        }

        public int DescriptionId { get; set; }

        public string DescriptionName { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public virtual ICollection<ProductDescription> ProductDescriptions { get; set; }

    }
}

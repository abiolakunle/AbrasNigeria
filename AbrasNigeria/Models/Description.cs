using System.Collections.Generic;


namespace AbrasNigeria.Models
{
    public class Description
    {
        public Description()
        {
            Products = new HashSet<ProductDescription>();
        }

        public long DescriptionId { get; set; }

        public string DescriptionName { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public ICollection<ProductDescription> Products { get; set; }

    }
}

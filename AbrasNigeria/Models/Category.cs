using System.Collections.Generic;


namespace AbrasNigeria.Models
{
    public class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}

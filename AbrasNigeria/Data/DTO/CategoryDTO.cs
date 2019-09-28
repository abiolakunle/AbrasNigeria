using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.DTO
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}

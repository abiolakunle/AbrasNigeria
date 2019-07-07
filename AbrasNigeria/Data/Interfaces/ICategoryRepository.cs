using System.Collections.Generic;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> loadAllWithProducts();
    }
}

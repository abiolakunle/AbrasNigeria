using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;
using System.Collections.Generic;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<BrandDTO> Search(string searchQuery);
    }
}

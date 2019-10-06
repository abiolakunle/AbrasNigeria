using System.Collections.Generic;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IDescriptionRepository : IRepository<Description>
    {
        IEnumerable<Description> LoadAllWithProducts();
        IEnumerable<DescriptionDTO> Search(string searchQuery);
    }
}

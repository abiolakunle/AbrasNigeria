using System.Collections.Generic;
using System.Threading.Tasks;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IMachineRepository : IRepository<Machine>
    {
        IEnumerable<Machine> LoadAllWithBrand();
        Machine LoadWithBrandSection(long id);
        IEnumerable<Machine> Search(string searchQuery);
    }
}

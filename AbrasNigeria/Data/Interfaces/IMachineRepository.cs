using System.Collections.Generic;
using System.Threading.Tasks;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IMachineRepository : IRepository<Machine>
    {
        Task<IEnumerable<MachineDTO>> LoadAllWithBrand();
        MachineDTO LoadWithBrandSection(int id);
        IEnumerable<MachineDTO> Search(string searchQuery);
    }
}

using System.Collections.Generic;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface IMachineRepository : IRepository<Machine>
    {
        IEnumerable<Machine> LoadAllWithBrand();
        Machine LoadWithBrandSection(int id);
    }
}

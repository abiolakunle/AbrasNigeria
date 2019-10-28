using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using AbrasNigeria.Data.DbContexts;

namespace AbrasNigeria.Data.Repositories
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(PartsBookDbContext context) : base(context)
        {
        }

        public IEnumerable<Machine> LoadAllWithBrand()
        {
            return _table
                .Include(m => m.Brand);
        }

        public Machine LoadWithBrandSection(long id)
        {
            return _table.Where(m => m.MachineId == id)
                .Include(m => m.Brand)
                .Include(m => m.Sections).ThenInclude(m => m.Section)
                .Include(m => m.SectionGroups).ThenInclude(m => m.SectionGroup)
                .Include(m => m.SectionGroupProducts)
                .ThenInclude(mp => mp.Product)
                .ThenInclude(p => p.Descriptions)
                .ThenInclude(p => p.Description)
                .FirstOrDefault();
        }

        public IEnumerable<Machine> Search(string searchQuery)
        {
            return _table.Where(m => m.ModelName.Contains(searchQuery));
        }
    }
}

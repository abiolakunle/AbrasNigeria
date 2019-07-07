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
        public MachineRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Machine> LoadAllWithBrand()
        {
            return _context.Machines.Include(m => m.Brand);
        }


        public Machine LoadWithBrandSection(int id)
        {
            return _context.Machines.Include(b => b.Brand).ThenInclude(msg => msg.Products)
                .Include(m => m.MachineSections)
                .ThenInclude(ms => ms.Section)
                .Include(m => m.MachineSectionGroups)
                .ThenInclude(msg => msg.SectionGroup).FirstOrDefault();
                
        }
    }
}

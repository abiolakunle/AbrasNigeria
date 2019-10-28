using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class SectionGroupRepository : Repository<SectionGroup>, ISectionGroupRepository
    {
        public SectionGroupRepository(PartsBookDbContext context) : base(context)
        {

        }

        public IEnumerable<SectionGroupDTO> Search(string searchQuery)
        {
            return _table
                .Where(sg => sg.SectionGroupName.Contains(searchQuery))
                .Select(sg => new SectionGroupDTO
                {
                    SectionGroupName = sg.SectionGroupName
                });
        }
    }
}

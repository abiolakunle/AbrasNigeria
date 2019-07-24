using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;
using System.Collections.Generic;

namespace AbrasNigeria.Data.Interfaces
{
    public interface ISectionGroupRepository : IRepository<SectionGroup>
    {
        IEnumerable<SectionGroupDTO> Search(string searchQuery);
    }
}

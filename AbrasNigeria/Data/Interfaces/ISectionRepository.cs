using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;
using System.Collections.Generic;

namespace AbrasNigeria.Data.Interfaces
{
    public interface ISectionRepository : IRepository<Section>
    {
        IEnumerable<SectionDTO> Search(string searchQuery);
    }
}

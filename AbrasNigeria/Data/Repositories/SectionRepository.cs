using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;


namespace AbrasNigeria.Data.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(AppDbContext context) : base(context)
        {
        }
    }
}

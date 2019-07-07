using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;


namespace AbrasNigeria.Data.Repositories
{
    public class SectionGroupRepository : Repository<SectionGroup>, ISectionGroupRepository
    {
        public SectionGroupRepository(AppDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}

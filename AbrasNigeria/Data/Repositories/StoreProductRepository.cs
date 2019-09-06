using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Repositories
{
    public class StoreProductRepository : Repository<StoreProduct>, IStoreProductRepository
    {

        public StoreProductRepository(AppDbContext context) : base(context)
        {

        }

    }
}

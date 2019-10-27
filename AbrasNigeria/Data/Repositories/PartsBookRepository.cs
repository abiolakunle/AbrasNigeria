using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Repositories
{
    public class PartsBookRepository<T> : Repository<T> where T : class
    {

        public PartsBookRepository(PartsBookDbContext context) : base(context)
        {

        }

    }
}

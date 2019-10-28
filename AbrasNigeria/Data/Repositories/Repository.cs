using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.DbContexts;

namespace AbrasNigeria.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbContext _context;
        protected readonly DbSet<T> _table;

        protected void Save() => _context.SaveChanges();

        public Repository(IDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();

        }

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Count();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}

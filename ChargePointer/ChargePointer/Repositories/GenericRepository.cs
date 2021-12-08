using System;
using System.Collections.Generic;
using System.Linq;
using ChargePointer.Data;
using Microsoft.EntityFrameworkCore;

namespace ChargePointer.Repositories
{
    public class GenericRepository<T, PK> : IRepository<T, PK>
        where T : class
    {
        private readonly ChargePointerDbContext _dbContext;
        private readonly DbSet<T> _table;

        public GenericRepository(ChargePointerDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public virtual T Get(PK id)
        {
            var entity = _table.Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public virtual void Create(T t)
        {
            _table.Add(t);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T t)
        {
            var entity = _dbContext.Entry(t);
            if (entity is null)
            {
                throw new InvalidOperationException("This object does not exist.");
            }

            _table.Attach(t);
            _dbContext.Entry(t).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void Delete(PK id)
        {
            var entity = Get(id);
            if (entity is null)
            {
                throw new InvalidOperationException("This object does not exist!");
            }

            _table.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
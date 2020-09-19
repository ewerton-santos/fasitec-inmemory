using System;
using System.Linq;
using System.Linq.Expressions;
using Fasitec.Business.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();            
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual IQueryable<T> GetAll(string include = "")
        {
            return _dbSet.AsNoTracking().Include(include);
        }

        public virtual IQueryable<T> Search(Expression<Func<T, bool>> predicate, string include = "")
        {
            return _dbSet.AsNoTracking().Where(predicate).Include(include);
        }

        public virtual T GetById(object entityId)
        {
            return _dbSet.Find(entityId);
        }

        public virtual T Insert(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }               

        public virtual T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
        
        public virtual void Remove(object entityId)
        {
            _dbSet.Remove(_dbSet.Find(entityId));            
        }         
    }
}
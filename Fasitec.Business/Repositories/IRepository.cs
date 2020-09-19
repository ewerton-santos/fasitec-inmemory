using System;
using System.Linq;
using System.Linq.Expressions;

namespace Fasitec.Business.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(string include = "");
        IQueryable<T> Search(Expression<Func<T, bool>> predicate, string include = "");
        T GetById(object entityId);
        T Insert(T entity);
        T Update(T entity);
        void Remove(object entityId);
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;
using Fasitec.Business.Entities;

namespace Service.Repositories
{
    public interface IUserRepository    
    {
        IQueryable<User> GetAll();
        IQueryable<User> GetAll(string include = "");
        IQueryable<User> Search(Expression<Func<User, bool>> predicate, string include = "");
        User GetById(int entityId);
        User Insert(User entity);
        User Update(User entity);
        void Remove(object entityId);
    }
}
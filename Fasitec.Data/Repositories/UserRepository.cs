using System;
using System.Linq;
using System.Linq.Expressions;
using Fasitec.Business.Entities;
using Fasitec.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Repositories;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _repository;
        public UserRepository(IRepository<User> repository)
        {
            _repository = repository;
        }

        public IQueryable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<User> GetAll(string include ="")
        {
            return _repository.GetAll(include);
        }

        public IQueryable<User> Search(Expression<Func<User, bool>> predicate, string include = "")
        {
            return _repository.Search(predicate, include);
        }

        public User GetById(int entityId)
        {
            return _repository.GetById(entityId);
        }

        public User Insert(User entity)
        {
            return _repository.Insert(entity);
        }        

        public User Update(User entity)
        {
            return _repository.Update(entity);
        }

        public void Remove(object entityId)
        {
            _repository.Remove(entityId);
        }
    }
}
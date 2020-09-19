using System.Linq;
using AutoMapper;
using Fasitec.Business.Dto;
using Fasitec.Business.Entities;
using Fasitec.Business.Unities;
using Service.Repositories;

namespace Fasitec.Business.ApplicationServices
{
    public class UserService : IUserFacade
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.userRepository = userRepository; 
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
            
        public IQueryable<UserOutput> All()
        {
            var users = userRepository.GetAll();
            return mapper.ProjectTo<UserOutput>(users);            
        }

        public UserOutput ById(int userId)
        {
            var user = userRepository.GetById(userId);
            return mapper.Map<UserOutput>(user);
        }

        public UserOutput Create(UserInput user)
        {
            var _user = mapper.Map<User>(user);
            var newUser = userRepository.Insert(_user);
            unitOfWork.Commit();
            return mapper.Map<UserOutput>(newUser);
        }

        public UserOutput Modify(UserInput user)
        {
            var _user = mapper.Map<User>(user);            
            var userModified = userRepository.Update(_user);
            unitOfWork.Commit();
            return mapper.Map<UserOutput>(userModified);
        }

        public void Remove(int userId)
        {        
            userRepository.Remove(userId);
            unitOfWork.Commit();
        }

        public UserOutput Signin(string email, string password)
        {
            var user = userRepository
            .GetAll()
            .Single(x => x.Email == email && x.Password == password);

            return mapper.Map<UserOutput>(user);
        }
    }
}
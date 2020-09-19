using System.Linq;
using Fasitec.Business.Dto;

namespace Fasitec.Business.ApplicationServices
{
    public interface IUserFacade
    {
        IQueryable<UserOutput> All();
        UserOutput Signin(string email, string password);
        UserOutput ById(int userId);
        UserOutput Create(UserInput user);
        UserOutput Modify(UserInput user);
        void Remove(int userId);
    }
}
using ApplicationsServices.DTOs.Users;
using DomainClass.Entity;

namespace ApplicationsServices.Services
{
    public interface IUserService
    {
        public Task<int> AddUser(UserSystem user);
    }
}

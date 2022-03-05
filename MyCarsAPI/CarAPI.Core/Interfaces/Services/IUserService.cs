using MyCarsAPI.Models;

namespace MyCarsAPI.CarAPI.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> AddUser(AddUserRequest request);
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        bool DeleteUser(int id);
        Task<User> UpdateUser(User request);
        Task<User> GetUserByUsernamePassword(string username, string password);
        void CommitAll();

    }
}

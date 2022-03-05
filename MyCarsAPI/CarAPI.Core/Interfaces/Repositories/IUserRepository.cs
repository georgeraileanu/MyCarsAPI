using MyCarsAPI.Models;

namespace MyCarsAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        bool UserExists(User user);
        public User GetUserByUsernamePassword(string username, string password);
        void CommitAll();
    }
}

using AutoMapper;
using MyCarsAPI.Models;
using MyCarsAPI.Repositories;

namespace MyCarsAPI.CarAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper; 

        public UserRepository(ApplicationDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }

        public void CommitAll()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
           _dbContext.Users.Remove(GetById(id));
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User user)
        {
            var oldUser = GetById(user.Id);

            if (oldUser != null)
                oldUser = _mapper.Map<User>(user);
            else
                _dbContext.Users.Add(user);
        }

        public User GetUserByUsernamePassword(string username, string password)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public bool UserExists(User user)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using MyCarsAPI.CarAPI.Core.Interfaces.Services;
using MyCarsAPI.Models;
using MyCarsAPI.Repositories;

namespace MyCarsAPI.CarAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> AddUser(AddUserRequest request)
        {

            var entity = _mapper.Map<User>(request);
            _userRepository.Add(entity);

            return entity;
            
        }

        public async void CommitAll()
        {
            _userRepository.CommitAll();
        }

        public bool DeleteUser(int id)
        {   
            _userRepository.Delete(id);
            return true;
        }

        public async Task<List<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<User> UpdateUser(User request)
        {
            _userRepository.Update(request);

            return request;

        }

        public async Task<User> GetUserByUsernamePassword(string username, string password)
        {
            return  _userRepository.GetUserByUsernamePassword(username, password);
        }
    }
}

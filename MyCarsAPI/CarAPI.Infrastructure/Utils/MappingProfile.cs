using AutoMapper;
using MyCarsAPI.CarAPI.Core.Interfaces.Services;
using MyCarsAPI.Models;

namespace MyCarsAPI.CarAPI.Infrastructure.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, AddUserRequest>().ReverseMap();
        }
    }
}

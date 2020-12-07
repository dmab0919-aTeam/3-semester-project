using AutoMapper;
using NordicBio.dal.Entities;
using NordicBio.model;

namespace NordicBio.api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}

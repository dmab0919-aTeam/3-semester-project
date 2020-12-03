using AutoMapper;
using NordicBio.dal.Entities;
using NordicBio.model;

namespace NordicBio.api.Profiles
{
    public class ShowingProfile : Profile
    {
        public ShowingProfile()
        {
            CreateMap<Showing, ShowingDTO>();
            CreateMap<ShowingDTO, Showing>();
        }
    }
}

using AutoMapper;
using NordicBio.dal.Entities;
using NordicBio.model;

namespace NordicBio.api.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>();
        }
    }
}

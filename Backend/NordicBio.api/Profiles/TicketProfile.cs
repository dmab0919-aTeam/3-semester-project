using AutoMapper;
using NordicBio.dal.Entities;
using NordicBio.model;

namespace NordicBio.api.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDTO>();

        }
    }
}

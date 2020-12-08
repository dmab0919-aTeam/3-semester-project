using AutoMapper;
using NordicBio.dal.Entities;
using NordicBio.model;

namespace NordicBio.api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}

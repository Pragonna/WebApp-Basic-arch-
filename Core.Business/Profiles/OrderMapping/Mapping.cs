
using AutoMapper;
using Core.Business.Dtos.OrderDtos;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.Profiles.OrderMapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            


            CreateMap<OrderDetails, OrderListDto>().ReverseMap();
            CreateMap<Order, OrderDetailsDto>().ReverseMap();
        }
    }
}

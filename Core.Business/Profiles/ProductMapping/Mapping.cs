using AutoMapper;
using Core.Business.Dtos.ProductDtos;
using Core.Domain.Entities;

namespace Core.Business.Profiles.ProductMapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductAddDto>()
               .ReverseMap()
               .ForMember(c => c.Id, res => res.Ignore())
               .ForMember(c => c.Category, res => res.Ignore())
               .ForMember(c => c.CreatedDate, res => res.Ignore())
               .ForMember(c => c.ModifiedDate, res => res.Ignore());

            CreateMap<Product, ProductListDto>()
                .ReverseMap();
        }
    }
}

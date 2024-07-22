using AutoMapper;
using Core.Business.Dtos.CategoryDtos;
using Core.Domain.Entities;

namespace Core.Business.Profiles.CategoryMapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryAddOrUpdateDto>()
                .ReverseMap()
                .ForMember(c => c.Id, res => res.Ignore())
                .ForMember(c => c.CreatedDate, res => res.Ignore())
                .ForMember(c => c.ModifiedDate, res => res.Ignore())
                .ForMember(c => c.Products, res => res.Ignore());

            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}

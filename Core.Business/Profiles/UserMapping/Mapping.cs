using AutoMapper;
using Core.Business.Dtos.UserDtos;
using Core.Security.Entities;

namespace Core.Business.Profiles.UserMapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserRegisterOrListDto>()
                .ForMember(c => c.Password, res => res.Ignore())
                .ReverseMap()
                .ForMember(c => c.PasswordHash, res => res.Ignore())
                .ForMember(c => c.PasswordSalt, res => res.Ignore())
                .ForMember(c => c.Status, res => res.Ignore())
                .ForMember(c => c.Id, res => res.Ignore())
                .ForMember(c => c.CreatedDate, res => res.Ignore())
                .ForMember(c => c.ModifiedDate, res => res.Ignore());

            CreateMap<User, UserListDto>()
                .ForMember(c => c.Roles, res => res.Ignore());

        }
    }
}

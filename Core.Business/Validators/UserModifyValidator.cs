using Core.Business.Dtos.UserDtos;
using FluentValidation;

namespace Core.Business.Validators
{
    public class UserModifyValidator:AbstractValidator<UserModifyDto>
    {
        public UserModifyValidator()
        {
            RuleFor(x=>x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.UserRoleDto.Roles)
                .NotEmpty()
                .NotNull();
        }
    }
}

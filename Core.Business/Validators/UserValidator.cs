using Core.Business.Dtos.UserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Validators
{
    public class UserValidator:AbstractValidator<UserRegisterOrListDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20)
                .MinimumLength(3);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20)
                .MinimumLength(3);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(20)
                .MinimumLength(3);

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .MinimumLength(8);

            RuleFor(x => x.Gender)
                .NotEmpty()
                .NotNull();

        }
    }
}

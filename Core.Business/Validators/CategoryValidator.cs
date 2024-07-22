using Core.Business.Dtos.CategoryDtos;
using FluentValidation;

namespace Core.Business.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryAddOrUpdateDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20)
                .MinimumLength(3);

            RuleFor(x => x.CategoryDescription)
                .MaximumLength(100);
        }
    }
}

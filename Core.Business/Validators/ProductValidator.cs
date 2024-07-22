
using Core.Business.Dtos.ProductDtos;
using FluentValidation;

namespace Core.Business.Validators
{
    public class ProductValidator:AbstractValidator<ProductAddDto>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.ProductName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20)
                .MinimumLength(3);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

        }
    }
}

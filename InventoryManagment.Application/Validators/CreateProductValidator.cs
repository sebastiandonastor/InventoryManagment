using FluentValidation;
using InventoryManagment.Application.DTOs;

namespace InventoryManagment.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} Shoudn't be empty");
        }
    }
}

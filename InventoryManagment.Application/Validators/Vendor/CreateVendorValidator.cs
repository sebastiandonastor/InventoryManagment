using FluentValidation;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Persistence.Contracts;

namespace InventoryManagment.Application.Validators
{
    public class CreateVendorValidator : AbstractValidator<VendorDto>
    {
        public CreateVendorValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 125 characters.")
                .NotNull();
        }
    }
}

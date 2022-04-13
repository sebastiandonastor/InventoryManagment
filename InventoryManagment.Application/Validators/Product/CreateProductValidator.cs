using FluentValidation;
using InventoryManagment.Application.DTOs.Product;
using InventoryManagment.Application.Persistence.Contracts;

namespace InventoryManagment.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(256).WithMessage("{PropertyName} must not exceed 256 characters.")
                .NotNull()
                .MustAsync(async (name, token) => {
                    var isProductDuplicated = await _productRepository.AnyAsync(p => p.Name == name);
                    return !isProductDuplicated;
                })
                .WithMessage("{PropertyName} '{PropertyValue}' is duplicated. Please write another one.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .NotNull();

        }
    }
}

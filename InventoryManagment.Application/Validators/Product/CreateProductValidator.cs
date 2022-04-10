using FluentValidation;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Persistence.Contracts;

namespace InventoryManagment.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 125 characters.")
                .NotNull()
                .MustAsync(async (name, token) => !(await _productRepository.AnyAsync(p => p.Name == name)));

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .NotNull()
                .MaximumLength(125).WithMessage("{PropertyName} must not exceed 125 characters.");

        }
    }
}

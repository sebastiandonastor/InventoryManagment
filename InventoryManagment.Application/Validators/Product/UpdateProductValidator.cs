using FluentValidation;
using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Persistence.Contracts;

namespace InventoryManagment.Application.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(async (product, token) => !(await _productRepository.AnyAsync(p => p.Id == product.Id && p.Name == product.Name)))
                .WithMessage("{PropertyName} must not be duplicated");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 125 characters.")
                .NotNull();

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .NotNull()
                .MaximumLength(125).WithMessage("{PropertyName} must not exceed 125 characters.");

        }
    }
}

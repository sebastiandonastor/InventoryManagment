using FluentValidation;
using InventoryManagment.Application.DTOs;

namespace InventoryManagment.Application.Validators.Product
{
    public class UpdateVendorValidator : AbstractValidator<VendorDto>
    {
        public UpdateVendorValidator()
        {
            Include(new CreateVendorValidator());
        }
    }
}

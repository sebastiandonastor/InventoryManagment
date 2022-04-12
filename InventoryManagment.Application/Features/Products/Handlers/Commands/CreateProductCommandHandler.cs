using AutoMapper;
using InventoryManagment.Application.Contracts.Infrastructure;
using InventoryManagment.Application.Features.Products.Requests.Commands;
using InventoryManagment.Application.Models;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Application.Responses;
using InventoryManagment.Application.Validators;
using InventoryManagment.Domain;
using MediatR;

namespace InventoryManagment.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private IEmailSender _emailSender;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper, 
            IEmailSender emailSender)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<CommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (!validationResult.IsValid)
                return new CommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                    Message = "Creation Failed"
                };

            var product = _mapper.Map<Product>(request.ProductDto);
            await _productRepository.AddAsync(product);

            var email = new Email()
            {
                To = "someemail@gmail.com",
                Body = "Congrats you just created a product :D",
                Subject = $"Product {product.Name} successfully created"
            };
            try
            {
               await _emailSender.SendEmail(email);
            }
            catch (Exception)
            {

                throw;
            }

            return new CommandResponse()
            {
                Id = product.Id,
                Message = "Creation Succesful"
            };

        }
    }
}

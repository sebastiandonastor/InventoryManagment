using AutoMapper;
using InventoryManagment.Application.Contracts.Infrastructure;
using InventoryManagment.Application.Contracts.Persistence;
using InventoryManagment.Application.Features.Products.Requests.Commands;
using InventoryManagment.Application.Models;
using InventoryManagment.Application.Responses;
using InventoryManagment.Application.Validators;
using InventoryManagment.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InventoryManagment.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CreateProductCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            IEmailSender emailSender,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<CommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductValidator(_unitOfWork.ProductRepository);
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (!validationResult.IsValid)
                return new CommandResponse()
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList(),
                    Message = "Creation Failed"
                };

            var product = _mapper.Map<Product>(request.ProductDto);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.Save();

            try
            {
                var emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var email = new Email()
                {
                    To = emailAddress,
                    Body = "Congrats you just created a product :D",
                    Subject = $"Product {product.Name} successfully created"
                };
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

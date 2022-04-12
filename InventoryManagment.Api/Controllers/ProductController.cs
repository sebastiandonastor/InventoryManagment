using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.DTOs.Product;
using InventoryManagment.Application.Features.Products.Requests;
using InventoryManagment.Application.Features.Products.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var products = await _mediator.Send(new GetProductListRequest());
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductDetailRequest() { Id = id});
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductDto productDto)
        {
            var command = new CreateProductCommand() { ProductDto = productDto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<ProductController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDto productDto)
        {
            var command = new UpdateProductCommand() { ProductDto = productDto };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = await _mediator.Send(new DeleteProductCommand() { Id = id });
            await _mediator.Send(command);

            return NoContent();
        }
    }
}

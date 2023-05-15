using CQRSWithMediatr.Commands;
using CQRSWithMediatr.Entities;
using CQRSWithMediatr.Notifications;
using CQRSWithMediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            var newProduct = await _mediator.Send(new AddProductCommand(product));
            await _mediator.Publish(new ProductAddedNotification(newProduct));

            return CreatedAtRoute(nameof(GetProductById),new { id = newProduct.Id },newProduct);
        }

        [HttpGet("{id:int}",Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }
    }
}

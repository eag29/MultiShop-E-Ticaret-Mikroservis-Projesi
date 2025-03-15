using _MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using _MultiShop.Order.Application.Features.Mediator.Commands;
using _MultiShop.Order.Application.Features.Mediator.Queires;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingGetById(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpGet("GetOrderingByUserId")]
        public async Task<IActionResult> GetOrderingByUserId(string id)
        {
            var values = await _mediator.Send(new GetOrderingByUserIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }
    }
}

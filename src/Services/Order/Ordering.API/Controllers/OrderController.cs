using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands.CheckoutOrder;
using Ordering.Application.Commands.DeleteOrder;
using Ordering.Application.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetBuyedCars;
using Ordering.Application.Features.Orders.Queries.GetBuyedCarsByUserName;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Application.Features.Orders.Queries.GetSoldCars;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetBuyedCars;
using Ordering.Application.Queries.GetBuyedCarsByUserName;
using Ordering.Application.Queries.GetSoldCars;
using Ordering.Domain.Entities;
using System.Net;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]/{userName}")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVM>>> GetOrdersByUserName(string userName)
        {
            var query = new GetOrdersListQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("[action]/{userName}")]
        [ProducesResponseType(typeof(IEnumerable<BuyedUserNameVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BuyedUserNameVM>>> GetBuyedCarsByUserName(string userName)
        {
            var queryBuyedCarsUserName = new GetBuyedCarsByUserNameQuery(userName);
            var getBuyedCarsUserName = await _mediator.Send(queryBuyedCarsUserName);
            return Ok(getBuyedCarsUserName);
        }

        [HttpGet("GetBuyedCars")]
        [ProducesResponseType(typeof(IEnumerable<BuyedVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BuyedVM>>> GetBuyedCars()
        {
            var queryGetBuyedCars = new GetBuyedCarsQuery();
            var getBuyedCars = await _mediator.Send(queryGetBuyedCars);
            return Ok(getBuyedCars);
        }

        [HttpGet("GetSoldCars")]
        [ProducesResponseType(typeof(IEnumerable<SoldVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SoldVM>>> GetSoldCars()
        {
            var queryGetSoldCars = new GetSoldCarsQuery();
            var getSoldCars = await _mediator.Send(queryGetSoldCars);
            return Ok(getSoldCars);
        }

        // testing purpose
        [HttpPost("CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

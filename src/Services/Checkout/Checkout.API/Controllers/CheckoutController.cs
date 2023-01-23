using AutoMapper;
using Checkout.API.Entities;
using Checkout.API.Repositories;
using Eventbus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Checkout.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public CheckoutController(IBasketRepository repository, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        [HttpGet("[action]/{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Basket>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);
            return Ok(basket ?? new Basket(userName));
        }

        [HttpPost("UpdateBasket")]
        [ProducesResponseType(typeof(Basket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Basket>> UpdateBasket([FromBody] Basket basket)
        {
            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete("[action]/{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> BasketCheckout([FromBody] BasketCheckout basketCheckout)
        {
            // get existing basket with total price
            // create basketcheckoutevent -- set totalprice on basketcheckout eventMessage
            // send checkout event to rabbitmq
            // remove the basket
            // get existing basket with total price
            var basket = await _repository.GetBasket(basketCheckout.UserName);
            if (basket == null)
            {
                return BadRequest();
            }
            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<CheckoutEvent>(basketCheckout);            
            eventMessage.TotalPrice = basket.TotalPrice;
            eventMessage.UserName = basket.UserName;
            eventMessage.Buyer = eventMessage.UserName;
            eventMessage.Seller = basket.Seller;

            await _publishEndpoint.Publish<CheckoutEvent>(eventMessage);

            // remove the basket
            await _repository.DeleteBasket(basket.UserName);

            return Accepted();
        }
    }
}

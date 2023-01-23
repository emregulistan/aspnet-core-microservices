using AutoMapper;
using Checkout.API.Entities;
using Eventbus.Messages.Events;

namespace Checkout.API.Mapper
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<BasketCheckout, CheckoutEvent>().ReverseMap();
        }
    }
}

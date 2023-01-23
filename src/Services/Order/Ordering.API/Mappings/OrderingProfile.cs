using AutoMapper;
using Eventbus.Messages.Events;
using Ordering.Application.Commands.CheckoutOrder;

namespace Ordering.API.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, CheckoutEvent>().ReverseMap();
        }
    }
}

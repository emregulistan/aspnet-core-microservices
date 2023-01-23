using AutoMapper;
using Ordering.Application.Commands.CheckoutOrder;
using Ordering.Application.Commands.UpdateOrder;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetBuyedCars;
using Ordering.Application.Queries.GetBuyedCarsByUserName;
using Ordering.Application.Queries.GetSoldCars;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVM>().ReverseMap();
            CreateMap<Order, BuyedUserNameVM>().ReverseMap();
            CreateMap<Order, BuyedVM>().ReverseMap();
            CreateMap<Order, SoldVM>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}

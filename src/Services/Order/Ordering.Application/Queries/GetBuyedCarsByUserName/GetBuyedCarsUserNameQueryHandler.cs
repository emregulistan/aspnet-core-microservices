using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Queries.GetBuyedCarsByUserName;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetBuyedCarsByUserName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetBuyedCarsUserName
{
    public class GetBuyedCarsUserNameQueryHandler : IRequestHandler<GetBuyedCarsByUserNameQuery, List<BuyedUserNameVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetBuyedCarsUserNameQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<BuyedUserNameVM>> Handle(GetBuyedCarsByUserNameQuery request, CancellationToken cancellationToken)
        {
            var buyedList = await _orderRepository.GetBuyedCarsByUserName(request.UserName);

            return _mapper.Map<List<BuyedUserNameVM>>(buyedList);
        }
    }
}

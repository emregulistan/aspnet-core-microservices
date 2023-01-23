using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Queries.GetSoldCars;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetSoldCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetSoldCarsQueryHandler : IRequestHandler<GetSoldCarsQuery, List<SoldVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetSoldCarsQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<SoldVM>> Handle(GetSoldCarsQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetSoldCars();
            return _mapper.Map<List<SoldVM>>(orderList);
        }
    }
}

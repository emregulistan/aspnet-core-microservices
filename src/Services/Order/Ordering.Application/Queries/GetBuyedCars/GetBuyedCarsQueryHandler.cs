using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetBuyedCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetBuyedCars
{
    public class GetBuyedCarsQueryHandler : IRequestHandler<GetBuyedCarsQuery, List<BuyedVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetBuyedCarsQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<BuyedVM>> Handle(GetBuyedCarsQuery request, CancellationToken cancellationToken)
        {
            var buyedCars = await _orderRepository.GetBuyedCars();
            return _mapper.Map<List<BuyedVM>>(buyedCars);
        }
    }
}

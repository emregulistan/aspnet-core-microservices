using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetBuyedCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetBuyedCars
{
    public class GetBuyedCarsQuery : IRequest<List<BuyedVM>>
    {
        public GetBuyedCarsQuery()
        {
        }
    }
}

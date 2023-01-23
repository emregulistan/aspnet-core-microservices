using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetSoldCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetSoldCars
{
    public class GetSoldCarsQuery : IRequest<List<SoldVM>>
    {
        public GetSoldCarsQuery()
        {
        }
    }
}

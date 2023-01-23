using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Queries.GetBuyedCarsByUserName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetBuyedCarsByUserName
{
    public class GetBuyedCarsByUserNameQuery : IRequest<List<BuyedUserNameVM>>
    {
        public string UserName { get; set; }

        public GetBuyedCarsByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}

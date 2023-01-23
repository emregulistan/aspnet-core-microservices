using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
        Task<IEnumerable<Order>> GetBuyedCarsByUserName(string userName);
        Task<IEnumerable<Order>> GetSoldCars();
        Task<IEnumerable<Order>> GetBuyedCars();
    }
}

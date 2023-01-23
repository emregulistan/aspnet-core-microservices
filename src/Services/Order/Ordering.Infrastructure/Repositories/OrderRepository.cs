using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                    .Where(o => o.UserName == userName)
                                    .ToListAsync();
            return orderList;
        }

        public async Task<IEnumerable<Order>> GetSoldCars()
        {
            var listOrder = await _dbContext.Orders
                                        .Select(x => new Order { Seller = x.Seller, CarName =  x.CarName })
                                        .ToListAsync();
            return listOrder;
        }

        public async Task<IEnumerable<Order>> GetBuyedCars()
        {
            var listOrderList = await _dbContext.Orders
                                        .Select(x => new Order { Buyer = x.Buyer, CarName = x.CarName })
                                        .ToListAsync();
            return listOrderList;
        }

        public async Task<IEnumerable<Order>> GetBuyedCarsByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                        .Where(or => or.UserName == userName)
                                        .Select(x => new Order { Buyer = x.Buyer, CarName = x.CarName })
                                        .ToListAsync();
            return orderList;
        }
    }
}

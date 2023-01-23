using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "Emre", TotalPrice = 321000, Buyer = "Emre", Seller = "Ertunc", CarName = "Fiast Egae", FirstName = "Emre", LastName = "Gul", EmailAddress = "example@example.com", AddressLine = "Address", Country = "Turkey", State = "State", ZipCode = "ZipCode", CardName = "CardName", CardNumber = "0000000000000000", Expiration = "3", CVV = "000", PaymentMethod = 2 },
                new Order() {UserName = "Ertunc", TotalPrice = 420000, Buyer = "Ertunc", Seller = "Emre", CarName = "Hondas Civics", FirstName = "Ertunc", LastName = "LastName", EmailAddress = "examples@example.com", AddressLine = "Address", Country = "Turkey", State = "State", ZipCode = "ZipCode", CardName = "CardName", CardNumber = "0000000000000000", Expiration = "6", CVV = "000", PaymentMethod = 3 }
            };
        }
    }
}


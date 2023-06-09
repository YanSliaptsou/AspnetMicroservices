using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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
                new Order() {
                    UserName = "swn",
                    FirstName = "Mehmet", 
                    LastName = "Ozkaya", 
                    EmailAddress = "ezozkme@gmail.com", 
                    AddressLine = "Bahcelievler", 
                    Country = "Turkey", 
                    TotalPrice = 350, 
                    CVV = "4568",
                    CardName = "xxxx",
                    CardNumber = "123",
                    Expiration = "June 2025",
                    PaymentMethod = 1,
                    State = "ok",
                    ZipCode = "2233",
                    /*CreatedBy = "swn",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = "swn",
                    LastModifiedDate = DateTime.Now*/
                }
            };
        }
    }
}

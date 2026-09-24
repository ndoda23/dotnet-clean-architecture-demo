using ECommerce.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Infrastructure;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        context.Database.Migrate();

        if (context.Products.Any())
        {
            return;
        }

        var p1 = new Product { Name = "Laptop", Price = 2500.00m };
        var p2 = new Product { Name = "Smartphone", Price = 1200.00m };
        var p3 = new Product { Name = "Headphones", Price = 150.00m };

        context.Products.AddRange(p1, p2, p3);
        context.SaveChanges();

        var order1 = new Order
        {
            OrderDate = DateTime.UtcNow.AddDays(-2),
            Items = new List<OrderItem>
            {
                new OrderItem { ProductId = p1.Id, Quantity = 2, UnitPrice = p1.Price }, 
                new OrderItem { ProductId = p3.Id, Quantity = 5, UnitPrice = p3.Price }  
            }
        };

        var order2 = new Order
        {
            OrderDate = DateTime.UtcNow.AddDays(-1),
            Items = new List<OrderItem>
            {
                new OrderItem { ProductId = p2.Id, Quantity = 10, UnitPrice = p2.Price },  
                new OrderItem { ProductId = p3.Id, Quantity = 1, UnitPrice = p3.Price }
            }
        };

        context.Orders.AddRange(order1, order2);
        context.SaveChanges();
    }
}
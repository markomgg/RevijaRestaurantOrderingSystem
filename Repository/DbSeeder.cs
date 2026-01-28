using Revija.Domain.Entities;
using Revija.Infrastructure.Data;

namespace Revija.Infrastructure;

public static class DbSeeder
{
    public static void Seed(RevijaDbContext context)
    {
        // Check if database has any menu items, if yes, we assume it's seeded
        if (context.MenuItems.Any())
        {
            return;
        }

        var burgers = new List<MenuItem>
        {
            new MenuItem { Name = "Classic Burger", Description = "Juicy beef patty with lettuce and tomato", Price = 200m, Category = "Burgers", IsAvailable = true },
            new MenuItem { Name = "Cheeseburger", Description = "Classic burger with cheddar cheese", Price = 230m, Category = "Burgers", IsAvailable = true },
            new MenuItem { Name = "Bacon Burger", Description = "Burger with crispy bacon", Price = 280m, Category = "Burgers", IsAvailable = true }
        };

        var drinks = new List<MenuItem>
        {
            new MenuItem { Name = "Coca Cola", Description = "Refreshing soda", Price = 80m, Category = "Drinks", IsAvailable = true },
            new MenuItem { Name = "Water", Description = "Still water", Price = 50m, Category = "Drinks", IsAvailable = true }
        };
        
        var salads = new List<MenuItem>
        {
            new MenuItem { Name = "Caesar Salad", Description = "Fresh salad with chicken", Price = 180m, Category = "Salads", IsAvailable = true }
        };

        context.MenuItems.AddRange(burgers);
        context.MenuItems.AddRange(drinks);
        context.MenuItems.AddRange(salads);

        // Add a sample customer
        var customer = new Customer
        {
            FullName = "Marko Markovski",
            Email = "marko@example.com",
            Phone = "070123456",
            Address = "Partizanska 10"
        };
        context.Customers.Add(customer);

        context.SaveChanges();
    }
}

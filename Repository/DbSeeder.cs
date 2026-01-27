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
            new MenuItem { Name = "Classic Burger", Description = "Juicy beef patty with lettuce and tomato", Price = 5.99m, Category = "Burgers", IsAvailable = true },
            new MenuItem { Name = "Cheeseburger", Description = "Classic burger with cheddar cheese", Price = 6.49m, Category = "Burgers", IsAvailable = true },
            new MenuItem { Name = "Bacon Burger", Description = "Burger with crispy bacon", Price = 7.49m, Category = "Burgers", IsAvailable = true }
        };

        var drinks = new List<MenuItem>
        {
            new MenuItem { Name = "Coca Cola", Description = "Refreshing soda", Price = 1.99m, Category = "Drinks", IsAvailable = true },
            new MenuItem { Name = "Water", Description = "Still water", Price = 1.00m, Category = "Drinks", IsAvailable = true }
        };
        
        var salads = new List<MenuItem>
        {
            new MenuItem { Name = "Caesar Salad", Description = "Fresh salad with chicken", Price = 4.99m, Category = "Salads", IsAvailable = true }
        };

        context.MenuItems.AddRange(burgers);
        context.MenuItems.AddRange(drinks);
        context.MenuItems.AddRange(salads);

        // Add a sample customer
        var customer = new Customer
        {
            Name = "Marko Markovski",
            Email = "marko@example.com",
            PhoneNumber = "070123456",
            Address = "Partizanska 10"
        };
        context.Customers.Add(customer);

        context.SaveChanges();
    }
}

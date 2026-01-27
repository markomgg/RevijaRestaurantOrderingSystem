using Revija.Domain.Entities;
using Revija.Domain.Interfaces;
using Revija.Infrastructure.Data;

namespace Revija.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RevijaDbContext _context;

    public OrderRepository(RevijaDbContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void AddItem(OrderItem item)
    {
        _context.OrderItems.Add(item);
        _context.SaveChanges();
    }
}

using Revija.Domain.Entities;

namespace Revija.Domain.Interfaces;

public interface IOrderRepository
{
    void Add(Order order);
    void AddItem(OrderItem item);
    // Add other methods as needed
}

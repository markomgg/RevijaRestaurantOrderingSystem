using Revija.Application.DTOs;
using Revija.Application.Interfaces;
using Revija.Domain.Entities;
using Revija.Domain.Enums;
using Revija.Domain.Interfaces;

namespace Revija.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IMenuItemRepository _menuRepository;

    public OrderService(IOrderRepository repository, IMenuItemRepository menuRepository)
    {
        _repository = repository;
        _menuRepository = menuRepository;
    }

    public OrderDto PlaceOrder(CreateOrderDto orderDto)
    {
        decimal total = 0;
        var orderItems = new List<OrderItem>();

        foreach (var itemDto in orderDto.Items)
        {
            var menuItem = _menuRepository.GetById(itemDto.MenuItemId);
            if (menuItem == null) continue; // Or throw exception

            decimal itemTotal = menuItem.Price * itemDto.Quantity;
            total += itemTotal;

            orderItems.Add(new OrderItem
            {
                MenuItemId = itemDto.MenuItemId,
                Quantity = itemDto.Quantity,
                Price = menuItem.Price
            });
        }

        var order = new Order
        {
            CustomerId = orderDto.CustomerId,
            Status = OrderStatus.Pending,
            TotalPrice = total,
            OrderDate = DateTime.UtcNow
        };

        _repository.Add(order); // Assumes generic add logic where ID is generated

        // Save order items if unrelated repository, but usually OrderRepo handles aggregate
        // Here assuming OrderRepo.Add handles OrderItems or we add them manually.
        // For simplicity and matching typical EF patterns, OrderRepo.Add(order) tracks graph if configured properly.
        // But our entity Order doesn't have List<OrderItem> property in Domain (Prompt Step 3 didn't show navigation prop).
        // Prompt Step 3: Order has CustomerId, OrderDate, Status, TotalPrice. No List<OrderItem>.
        // Prompt Step 3: OrderItem has OrderId.
        
        // So we must save Order first to get ID, then save OrderItems with that ID.
        
        foreach(var item in orderItems)
        {
            item.OrderId = order.Id;
            _repository.AddItem(item);
        }

        return new OrderDto
        {
            OrderId = order.Id,
            Status = order.Status,
            TotalPrice = order.TotalPrice
        };
    }
}

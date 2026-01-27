using Revija.Application.DTOs;

namespace Revija.Application.Interfaces;

public interface IOrderService
{
    OrderDto PlaceOrder(CreateOrderDto orderDto);
}

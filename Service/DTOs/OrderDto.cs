using Revija.Domain.Enums;

namespace Revija.Application.DTOs;

public class OrderDto
{
    public int OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
}

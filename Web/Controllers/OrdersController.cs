using Microsoft.AspNetCore.Mvc;
using Revija.Application.DTOs;
using Revija.Application.Interfaces;
using Revija.Infrastructure.Data;

namespace Revija.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;
    private readonly RevijaDbContext _db;

    public OrdersController(IOrderService service, RevijaDbContext db)
    {
        _service = service;
        _db = db;
    }

    [HttpPost]
    public IActionResult PlaceOrder([FromBody] CreateOrderDto orderDto)
    {
        var result = _service.PlaceOrder(orderDto);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = _db.Orders
            .Select(o => new OrderDto { OrderId = o.Id, Status = o.Status, TotalPrice = o.TotalPrice })
            .ToList();
        return Ok(orders);
    }
}

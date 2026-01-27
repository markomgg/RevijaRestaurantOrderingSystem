using Microsoft.AspNetCore.Mvc;
using Revija.Application.DTOs;
using Revija.Application.Interfaces;

namespace Revija.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult PlaceOrder([FromBody] CreateOrderDto orderDto)
    {
        var result = _service.PlaceOrder(orderDto);
        return Ok(result);
    }
}

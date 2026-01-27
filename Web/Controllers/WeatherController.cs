using Microsoft.AspNetCore.Mvc;
using Revija.Application.Interfaces;

namespace Revija.API.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _service;

    public WeatherController(IWeatherService service)
    {
        _service = service;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        try
        {
            var result = await _service.GetDeliveryWeatherAsync(city);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error fetching weather: {ex.Message}");
        }
    }
}

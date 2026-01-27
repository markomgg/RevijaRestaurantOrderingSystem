using Revija.Application.DTOs;
using Revija.Application.Interfaces;

namespace Revija.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherApiClient _client;

    public WeatherService(IWeatherApiClient client)
    {
        _client = client;
    }

    public async Task<DeliveryWeatherDto> GetDeliveryWeatherAsync(string city)
    {
        var weather = await _client.GetWeatherAsync(city);

        var condition = weather?.Weather.FirstOrDefault()?.Main ?? "Clear";
        var temp = weather?.Main.Temp ?? 0;

        string message = "Delivery conditions are normal.";

        if (condition.Contains("Rain") || condition.Contains("Snow"))
            message = "Delivery may be delayed due to bad weather.";

        if (temp < 0)
            message += " Roads might be slippery.";

        return new DeliveryWeatherDto
        {
            Temperature = temp,
            Condition = condition,
            DeliveryMessage = message
        };
    }
}

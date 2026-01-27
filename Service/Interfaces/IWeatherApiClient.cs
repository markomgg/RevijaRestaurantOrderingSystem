using Revija.Application.DTOs.External;

namespace Revija.Application.Interfaces;

public interface IWeatherApiClient
{
    Task<WeatherApiResponse?> GetWeatherAsync(string city);
}

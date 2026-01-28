using System.Net.Http.Json;
using Revija.Application.DTOs.External;
using Revija.Application.Interfaces;

namespace Revija.Infrastructure.ExternalServices;

public class WeatherApiClient : IWeatherApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "bed7198a27d6d37fa9078652f1430034";

    public WeatherApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherApiResponse?> GetWeatherAsync(string city)
    {
        return await _httpClient.GetFromJsonAsync<WeatherApiResponse>(
            $"weather?q={city}&units=metric&appid={_apiKey}");
    }
}

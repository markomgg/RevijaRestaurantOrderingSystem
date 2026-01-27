using System.Net.Http.Json;
using Revija.Application.DTOs.External;
using Revija.Application.Interfaces;

namespace Revija.Infrastructure.ExternalServices;

public class WeatherApiClient : IWeatherApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "bed7198a27d6d37fa9078652f1430034"; // Dummy or user provided. Prompt said "YOUR_API_KEY". I should probably leave it as placeholder or put a dummy. The user prompt used "YOUR_API_KEY" in the text but maybe I can find a free one or just leave it. Prompt said: "(ако сакаш, подоцна можеш да ставиш dummy key за проект)". I'll use a placeholder variable.

    public WeatherApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherApiResponse?> GetWeatherAsync(string city)
    {
        // Using sample API key or placeholder.
        // It's better to use configuration, but following prompt structure, I will hardcode or use Config.
        // Prompt suggestion: $"weather?q={city}&units=metric&appid=YOUR_API_KEY"
        // I will use a placeholder so it compiles, user can replace.
        var apiKey = "YOUR_Valid_OpenWeather_API_Key"; 
        return await _httpClient.GetFromJsonAsync<WeatherApiResponse>(
            $"weather?q={city}&units=metric&appid={apiKey}");
    }
}

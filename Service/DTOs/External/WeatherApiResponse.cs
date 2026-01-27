namespace Revija.Application.DTOs.External;

public class WeatherApiResponse
{
    public MainInfo Main { get; set; } = new();
    public List<WeatherInfo> Weather { get; set; } = new();
}

public class MainInfo
{
    public double Temp { get; set; }
}

public class WeatherInfo
{
    public string Main { get; set; } = string.Empty;
}

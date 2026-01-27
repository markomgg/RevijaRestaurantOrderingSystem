namespace Revija.Application.DTOs;

public class DeliveryWeatherDto
{
    public double Temperature { get; set; }
    public string Condition { get; set; } = string.Empty;
    public string DeliveryMessage { get; set; } = string.Empty;
}

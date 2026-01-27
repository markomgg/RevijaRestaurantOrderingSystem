using Revija.Application.DTOs;

namespace Revija.Application.Interfaces;

public interface IWeatherService
{
    Task<DeliveryWeatherDto> GetDeliveryWeatherAsync(string city);
}

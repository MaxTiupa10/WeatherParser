using WeatherParser.Domain.Entities;

namespace WeatherParser.Domain.Interfaces;

public interface IWeatherProviderService
{
    Task<IEnumerable<WeatherRecord>> GetHistoryAsync(string city);    
}
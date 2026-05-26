namespace WeatherParser.Domain.Interfaces;

using WeatherParser.Domain.Entities;

public interface IWeatherRepository
{
    Task SaveAsync(WeatherRecord weatherRecord);
    Task<IEnumerable<WeatherRecord>> GetHistoryAsync(string city);
    Task<WeatherRecord> GetByIdAsync(Guid id);
}
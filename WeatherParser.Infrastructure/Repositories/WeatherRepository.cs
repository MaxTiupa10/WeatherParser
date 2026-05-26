using Microsoft.EntityFrameworkCore;
using WeatherParser.Domain.Entities;
using WeatherParser.Domain.Interfaces;
using WeatherParser.Infrastructure.Data;

namespace WeatherParser.Infrastructure.Repositories;

public class WeatherRepository : IWeatherRepository
{
    private readonly AppDbContext _appDbContext;
    
    public WeatherRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task SaveAsync(WeatherRecord weatherRecord)
    {
        await _appDbContext.WeatherRecords.AddAsync(weatherRecord);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<WeatherRecord>> GetHistoryAsync(string city)
    {
        return await _appDbContext.WeatherRecords
            .Where(w => w.City.ToLower() == city.ToLower())
            .OrderByDescending(w => w.CapturedAt)
            .ToListAsync();
    }

    public async Task<WeatherRecord> GetByIdAsync(Guid id)
    {
        return await _appDbContext.WeatherRecords
            .FirstOrDefaultAsync(w => w.Id == id);
    }
    
}
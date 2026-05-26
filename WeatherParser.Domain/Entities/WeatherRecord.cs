namespace WeatherParser.Domain.Entities;

public class WeatherRecord
{
    public Guid Id { get; set; }
    public string City { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public double Pressure { get; set; }
    public DateTime CapturedAt { get; set; } = DateTime.UtcNow;
}
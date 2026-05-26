using Microsoft.EntityFrameworkCore;
using WeatherParser.Domain.Entities;

namespace WeatherParser.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<WeatherRecord> WeatherRecords => Set<WeatherRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WeatherRecord>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(w => w.City)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(w => w.Temperature).HasPrecision(5, 2);
            entity.Property(w =>w.Humidity).HasPrecision(5, 2);
            entity.Property(w => w.WindSpeed).HasPrecision(5, 2);
            entity.Property(w => w.Pressure).HasPrecision(5, 2);
        });
    }
}
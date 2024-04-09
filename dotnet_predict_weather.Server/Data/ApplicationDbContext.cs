using dotnet_predict_weather.Server.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace dotnet_predict_weather.Server.Models.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Device> Devices { get; set; }
}


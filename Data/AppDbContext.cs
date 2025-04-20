using Microsoft.EntityFrameworkCore;
using WeatherNewsAPI.SearchHistory.Models;
namespace WeatherNewsAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<HistoryRecord> HistoryRecord { get; set; } = null!;

}

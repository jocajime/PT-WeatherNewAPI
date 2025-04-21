using Microsoft.EntityFrameworkCore;
using WeatherNewsAPI.SearchHistory.Models;
namespace WeatherNewsAPI.Data;

/// <summary>
/// Representa el contexto de base de datos de la aplicación, proporcionando acceso a la base de datos
/// y gestionando los conjuntos de entidades para la aplicación.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="AppDbContext"/> con las opciones especificadas.
    /// </summary>
    /// <param name="options">Las opciones para configurar el contexto de base de datos.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Obtiene o establece el <see cref="DbSet{TEntity}"/> para las entidades <see cref="HistoryRecord"/>.
    /// </summary>
    public DbSet<HistoryRecord> HistoryRecord { get; set; } = null!;
}

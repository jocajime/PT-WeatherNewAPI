using Microsoft.EntityFrameworkCore;
using WeatherNewsAPI.SearchHistory.Interfaces;
using WeatherNewsAPI.SearchHistory.Models;
using WeatherNewsAPI.Data;

namespace WeatherNewsAPI.SearchHistory.Services;

/// <summary>
/// Servicio para gestionar las operaciones relacionadas con el historial de búsqueda.
/// Implementa la interfaz <see cref="ISearchHistoryService"/>.
/// </summary>
public class SearchHistoryService : ISearchHistoryService
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SearchHistoryService"/>.
    /// </summary>
    /// <param name="context">El contexto de base de datos utilizado para acceder al historial de búsqueda.</param>
    public SearchHistoryService(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task AddEntry(HistoryRecord entry)
    {
        entry.Id = Guid.NewGuid();
        entry.SearchDate = DateTime.UtcNow;

        _context.HistoryRecord.Add(entry);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<HistoryRecord>> GetAll()
    {
        return await _context.HistoryRecord.OrderByDescending(x => x.SearchDate).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<HistoryRecord>> GetByCity(string city)
    {
        return await _context.HistoryRecord
            .Where(x => x.City.ToLower() == city.ToLower())
            .OrderByDescending(x => x.SearchDate)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<HistoryRecord>> GetByType(string type)
    {
        return await _context.HistoryRecord
            .Where(x => x.SearchType.ToLower() == type.ToLower())
            .OrderByDescending(x => x.SearchDate)
            .ToListAsync();
    }
}

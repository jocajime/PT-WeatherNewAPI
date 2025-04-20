using Microsoft.EntityFrameworkCore;
using WeatherNewsAPI.SearchHistory.Interfaces;
using WeatherNewsAPI.SearchHistory.Models;
using WeatherNewsAPI.Data;

namespace WeatherNewsAPI.SearchHistory.Services;

public class SearchHistoryService : ISearchHistoryService
{
    private readonly AppDbContext _context;

    public SearchHistoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddEntry(HistoryRecord entry)
    {
        entry.Id = Guid.NewGuid();
        entry.SearchDate = DateTime.UtcNow;

        _context.HistoryRecord.Add(entry);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<HistoryRecord>> GetAll()
    {
        return await _context.HistoryRecord.OrderByDescending(x => x.SearchDate).ToListAsync();
    }

    public async Task<IEnumerable<HistoryRecord>> GetByCity(string city)
    {
        return await _context.HistoryRecord
            .Where(x => x.City.ToLower() == city.ToLower())
            .OrderByDescending(x => x.SearchDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoryRecord>> GetByType(string type)
    {
        return await _context.HistoryRecord
            .Where(x => x.SearchType.ToLower() == type.ToLower())
            .OrderByDescending(x => x.SearchDate)
            .ToListAsync();
    }

}

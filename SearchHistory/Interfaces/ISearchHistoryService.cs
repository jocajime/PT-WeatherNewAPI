using WeatherNewsAPI.SearchHistory.Models;

namespace WeatherNewsAPI.SearchHistory.Interfaces;

public interface ISearchHistoryService
{
    Task AddEntry(HistoryRecord entry);
    Task<IEnumerable<HistoryRecord>> GetAll();
    Task<IEnumerable<HistoryRecord>> GetByCity(string city);
    Task<IEnumerable<HistoryRecord>> GetByType(string type);

}

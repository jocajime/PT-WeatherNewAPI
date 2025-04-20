using System;

namespace WeatherNewsAPI.SearchHistory.Models;

public class HistoryRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string City { get; set; } = string.Empty;
    public string SearchType { get; set; } = string.Empty; // "news" o "weather"
    public DateTime SearchDate { get; set; } = DateTime.UtcNow;
}

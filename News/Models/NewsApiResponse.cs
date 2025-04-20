namespace WeatherNewsAPI.News.Models;

public class NewsApiResponse
{
    public string? Status { get; set; }
    public int TotalResults { get; set; }
    public List<Article>? Articles { get; set; }
}

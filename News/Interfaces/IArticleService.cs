namespace WeatherNewsAPI.News.Interfaces;
using WeatherNewsAPI.News.Models;

public interface IArticleService
{
    Task<List<Article>?> GetArticlesByCity(string city);
}

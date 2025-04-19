using WeatherNewsAPI.Models;
namespace WeatherNewsAPI.Services.Interfaces;

public interface IArticleService
{
    Task<List<Article>?> GetArticlesByCity(string city);
}

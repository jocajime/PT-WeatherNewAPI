using System.Text.Json;
using WeatherNewsAPI.News.Models;
using WeatherNewsAPI.News.Interfaces;

namespace WeatherNewsAPI.News.Services;

public class ArticleService : IArticleService
{

    private readonly HttpClient _httpClient;
    private IConfiguration _configuration;

    public ArticleService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("WeatherNewsClient/1.0");

    }
        
    public async Task<List<Article>?> GetArticlesByCity(string city)
    {
        var apiKey = _configuration["NewsApi:ApiKey"];
        var baseUrl = _configuration["NewsApi:BaseUrl"];
        var encodedCity = Uri.EscapeDataString(city);
        var url = $"{baseUrl}/everything?q={encodedCity}&apiKey={apiKey}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"NewsAPI Error: {response.ReasonPhrase}");
        
        var jsonResponse = await response.Content.ReadAsStringAsync();

        var ArticlesJson = JsonSerializer.Deserialize<NewsApiResponse>(jsonResponse, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return ArticlesJson?.Articles ?? new List<Article>();
    }
}

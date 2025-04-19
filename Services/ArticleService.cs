using System.Text.Json;
using WeatherNewsAPI.Models;
using WeatherNewsAPI.Services.Interfaces;

namespace WeatherNewsAPI.Services;

public class ArticleService : IArticleService
{

    private readonly HttpClient _httpClient;
    private IConfiguration _configuration;

    public ArticleService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
        
        public async Task<List<Article>?> GetArticlesByCity(string city)
        {
            var apiKey = _configuration["NewsApi:ApiKey"];
            var baseUrl = _configuration["NewsApi:BaseUrl"];
            var encodedCity = Uri.EscapeDataString(city);
            var url = $"{baseUrl}/everything?q={encodedCity}&apiKey={apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"NewsAPI Error: {response.ReasonPhrase}");
            }
            
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var Articles = JsonSerializer.Deserialize<NewsApiResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Articles?.Articles ?? new List<Article>();
    }
}

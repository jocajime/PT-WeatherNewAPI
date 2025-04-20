using System.Text.Json;
using WeatherNewsAPI.News.Models;
using WeatherNewsAPI.News.Interfaces;

namespace WeatherNewsAPI.News.Services;

/// <summary>
/// Servicio para gestionar la obtención de artículos de noticias desde la API externa.
/// </summary>
public class ArticleService : IArticleService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ArticleService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP utilizado para realizar solicitudes a la API de noticias.</param>
    /// <param name="configuration">Configuración de la aplicación para obtener claves y URLs de la API.</param>
    public ArticleService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("WeatherNewsClient/1.0");
    }
    
    /// <inheritdoc />
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

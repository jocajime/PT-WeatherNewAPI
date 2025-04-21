using System.Text.Json;
using WeatherNewsAPI.News.Models;
using WeatherNewsAPI.News.Interfaces;
using WeatherNewsAPI.SearchHistory.Interfaces;
using WeatherNewsAPI.SearchHistory.Models;

namespace WeatherNewsAPI.News.Services;

/// <summary>
/// Servicio para gestionar la obtención de artículos de noticias desde la API externa.
/// </summary>
public class ArticleService : IArticleService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ISearchHistoryService _searchHistoryService;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ArticleService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP utilizado para realizar solicitudes a la API de noticias.</param>
    /// <param name="configuration">Configuración de la aplicación para obtener claves y URLs de la API.</param>
    /// <param name="searchHistoryService">Servicio de historial de la aplicación para registrar las busquedas</param>
    public ArticleService(HttpClient httpClient, IConfiguration configuration, ISearchHistoryService searchHistoryService)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _searchHistoryService = searchHistoryService; 

        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("WeatherNewsClient/1.0");
    }
    
    /// <inheritdoc />
    public async Task<List<Article>?> GetArticlesByCity(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Ciudad no puede ser vacia.", nameof(city));

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
        // Guardar en el historial
        await _searchHistoryService.AddEntry(new HistoryRecord
        {
            City = city,
            SearchType = "news"
        });

        return ArticlesJson?.Articles ?? new List<Article>();
    }
}

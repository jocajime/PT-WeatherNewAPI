using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WeatherNewsWeb.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace WeatherNewsWeb.Pages;

/// <summary>
/// Modelo de página para la página principal (Index).
/// Gestiona la lógica de negocio para mostrar información del clima, noticias destacadas y el historial de búsquedas.
/// </summary>
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty(SupportsGet = true)]
    public string City { get; set; } = "Bogotá";
    public List<SearchHistoryModel> SearchHistory { get; set; } = new List<SearchHistoryModel>();

    public List<NewsModel> NewsList { get; set; } = new List<NewsModel>();
    public WeatherInfoModel WeatherInfo { get; set; } = new WeatherInfoModel();

    /// <summary>
    /// Constructor de la clase IndexModel.
    /// </summary>
    /// <param name="logger">Instancia de <see cref="ILogger"/> para registrar información de depuración.</param>
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Método que se ejecuta al cargar la página.
    /// Obtiene el historial de búsquedas, las noticias y la información del clima.
    /// </summary>
    public async Task OnGet()
    {
        SearchHistory = await ObtenerHistorialAsync();
        NewsList = await ObtenerNoticiasAsync(City);
        WeatherInfo = await ObtenerClimaAsync(City);
    }

    /// <summary>
    /// Obtiene la información del clima para una ciudad específica.
    /// </summary>
    /// <param name="city">Nombre de la ciudad.</param>
    /// <returns>Un objeto <see cref="WeatherInfoModel"/> con la información del clima.</returns>
    private async Task<WeatherInfoModel> ObtenerClimaAsync(string city)
    {
        using var httpClient = new HttpClient();
        var baseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
        var encodedCity = Uri.EscapeDataString(city);
        var url = $"{baseUrl}/api/Weather?city={encodedCity}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var WeatherInfo = await response.Content.ReadFromJsonAsync<WeatherInfoModel>();
            return WeatherInfo ?? new WeatherInfoModel();
        }

        return new WeatherInfoModel();
    }

    /// <summary>
    /// Obtiene una lista de noticias destacadas para una ciudad específica.
    /// </summary>
    /// <param name="city">Nombre de la ciudad.</param>
    /// <returns>Una lista de <see cref="NewsModel"/> con las noticias destacadas.</returns>
    private async Task<List<NewsModel>> ObtenerNoticiasAsync(string city)
    {
        using var httpClient = new HttpClient();
        var baseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
        var encodedCity = Uri.EscapeDataString(city);
        var url = $"{baseUrl}/api/news?city={encodedCity}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var news = await response.Content.ReadFromJsonAsync<List<NewsModel>>();
            return news ?? new List<NewsModel>();
        }

        return new List<NewsModel>();
    }

    /// <summary>
    /// Obtiene el historial de búsquedas realizadas por el usuario.
    /// </summary>
    /// <returns>Una lista de <see cref="SearchHistoryModel"/> con el historial de búsquedas.</returns>
    private async Task<List<SearchHistoryModel>> ObtenerHistorialAsync()
    {
        using var httpClient = new HttpClient();
        var baseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
        var url = $"{baseUrl}/api/SearchHistory/all";
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var historial = await response.Content.ReadFromJsonAsync<List<SearchHistoryModel>>();
            var historialAgrupado = (historial ?? new List<SearchHistoryModel>())
               .GroupBy(h => h.City.ToLower())
               .Select(g => new
               {
                   City = g.Key,
                   Veces = g.Count(),
                   UltimaFecha = g.Max(h => h.SearchDate)
               })
               .OrderByDescending(h => h.UltimaFecha)
               .ToList();

            return historialAgrupado.Select(h => new SearchHistoryModel
            {
                City = h.City,
                SearchCount = h.Veces,
                SearchDate = h.UltimaFecha
            }).ToList() ?? new List<SearchHistoryModel>();
        }

        return new List<SearchHistoryModel>();
    }
}

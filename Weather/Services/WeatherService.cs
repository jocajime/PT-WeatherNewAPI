using System.Text.Json;
using WeatherNewsAPI.Weather.Models;
using WeatherNewsAPI.Weather.Interfaces;

namespace WeatherNewsAPI.Weather.Services;

/// <summary>
/// Servicio para gestionar la obtención de información del clima desde la API de OpenWeather.
/// Implementa la interfaz <see cref="IWeatherService"/>.
/// </summary>
public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="WeatherService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP utilizado para realizar solicitudes a la API de OpenWeather.</param>
    /// <param name="configuration">Configuración de la aplicación para obtener claves y URLs de la API.</param>
    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    /// <inheritdoc />
    public async Task<WeatherResponse?> GetWeatherByCity(string city)
    {
        var apiKey = _configuration["OpenWeather:ApiKey"];
        var baseUrl = _configuration["OpenWeather:BaseUrl"];
        var encodedCity = Uri.EscapeDataString(city);
        var url = $"{baseUrl}/weather?q={encodedCity}&appid={apiKey}&units=metric&lang=es";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"OpenWeather API error: {response.ReasonPhrase}");

        var jsonResponse = await response.Content.ReadAsStringAsync();

        var WeatherJson = JsonSerializer.Deserialize<OpenWeatherApiResponse>(jsonResponse, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return new WeatherResponse
        {
            City = WeatherJson?.Name ?? city,
            Temperature = WeatherJson?.Main?.Temp ?? 0,
            Description = WeatherJson?.Weather?.FirstOrDefault()?.Description ?? "Sin descripción",
            Humidity = WeatherJson?.Main?.Humidity ?? 0,
            WindSpeed = WeatherJson?.Wind?.Speed ?? 0,
            Date = DateTimeOffset.FromUnixTimeSeconds(WeatherJson?.Dt ?? 0).DateTime
        };
    }
}

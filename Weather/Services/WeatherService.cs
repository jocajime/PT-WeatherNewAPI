using System.Text.Json;
using WeatherNewsAPI.Weather.Models;
using WeatherNewsAPI.Weather.Interfaces;

namespace WeatherNewsAPI.Weather.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

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

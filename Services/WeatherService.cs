using WeatherNewsAPI.Models;
using WeatherNewsAPI.Services.Interfaces;

namespace WeatherNewsAPI.Services;

public class WeatherService : IWeatherService
{
    public async Task<Weather?> GetWeatherByCity(string city)
    {
        await Task.Delay(1000); 

        return new Weather
        {
            City = city,
            Country = "US",
            Temperature = 75.0,
            WeatherCondition = "Sunny",
            Humidity = 50.0,
            WindSpeed = 10.0,
            LastUpdated = DateTime.UtcNow
        };
    }
}

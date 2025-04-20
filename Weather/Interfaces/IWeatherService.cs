using WeatherNewsAPI.Weather.Models;

namespace WeatherNewsAPI.Weather.Interfaces;

public interface IWeatherService
{
    Task<WeatherResponse?> GetWeatherByCity(string city);
}
using WeatherNewsAPI.Models;
namespace WeatherNewsAPI.Services.Interfaces;

public interface IWeatherService
{
    Task<Weather?> GetWeatherByCity(string city);
}
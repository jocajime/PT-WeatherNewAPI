using WeatherNewsAPI.Weather.Models;

namespace WeatherNewsAPI.Weather.Interfaces;

/// <summary>
/// Define la interfaz para el servicio de obtención de información del clima.
/// </summary>
public interface IWeatherService
{
    /// <summary>
    /// Obtiene la información del clima para una ciudad específica.
    /// </summary>
    /// <param name="city">El nombre de la ciudad para buscar la información del clima.</param>
    /// <returns>
    /// Una tarea que representa la operación asincrónica. El resultado contiene un objeto <see cref="WeatherResponse"/>
    /// con la información del clima de la ciudad especificada, o <c>null</c> si no se encuentra información.
    /// </returns>
    Task<WeatherResponse?> GetWeatherByCity(string city);
}
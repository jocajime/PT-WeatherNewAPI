using Microsoft.AspNetCore.Mvc;
using WeatherNewsAPI.Weather.Interfaces;
using WeatherNewsAPI.Weather.Models;

namespace WeatherNewsAPI.Weather.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con la obtención de información del clima.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="WeatherController"/>.
    /// </summary>
    /// <param name="weatherService">Servicio para gestionar la obtención de información del clima.</param>
    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    /// <summary>
    /// Obtiene la información del clima para una ciudad específica.
    /// </summary>
    /// <param name="city">El nombre de la ciudad para buscar la información del clima.</param>
    /// <returns>
    /// Una respuesta HTTP que contiene la información del clima de la ciudad especificada.
    /// Devuelve un código de estado 400 si el nombre de la ciudad está vacío.
    /// Devuelve un código de estado 500 si ocurre un error interno.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<WeatherResponse>> GetWeatherByCity([FromQuery] string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("El nombre de la ciudad no puede estar vacío.");
        }

        try
        {
            var weather = await _weatherService.GetWeatherByCity(city);
            return Ok(weather);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocurrió un error al obtener el clima para '{city}': {ex.Message}");
        }
    }
}

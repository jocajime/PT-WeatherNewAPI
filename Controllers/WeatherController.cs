using Microsoft.AspNetCore.Mvc;
using WeatherNewsAPI.Models;
using WeatherNewsAPI.Services.Interfaces;

namespace WeatherNewsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<ActionResult<Weather>> GetWeatherByCity([FromQuery] string city)
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

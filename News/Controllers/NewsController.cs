using Microsoft.AspNetCore.Mvc;
using WeatherNewsAPI.News.Models;
using WeatherNewsAPI.News.Interfaces;

namespace WeatherNewsAPI.News.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con los artículos de noticias.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly IArticleService _articleService;

    /// <summary>
    /// Constructor del controlador <see cref="NewsController"/>.
    /// </summary>
    /// <param name="articleService">Servicio para gestionar los artículos de noticias.</param>
    public NewsController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    /// <summary>
    /// Obtiene una lista de artículos de noticias relacionados con una ciudad específica.
    /// </summary>
    /// <param name="city">Nombre de la ciudad para buscar artículos de noticias.</param>
    /// <returns>
    /// Una lista de artículos de noticias relacionados con la ciudad especificada.
    /// Devuelve un código de estado 400 si la ciudad no es válida.
    /// Devuelve un código de estado 500 si ocurre un error interno.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByCity([FromQuery] string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("Ciudad no puede estar vacía.");
        }

        try
        {
            var news = await _articleService.GetArticlesByCity(city);
            return Ok(news);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al recuperar las noticias: {ex.Message}");
        }
    }
}


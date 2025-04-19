using Microsoft.AspNetCore.Mvc;
using WeatherNewsAPI.Models;
using WeatherNewsAPI.Services.Interfaces;

namespace WeatherNewsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly IArticleService _articleService;

    public NewsController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByCity([FromQuery] string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("Ciudad no puede estar vacia.");
        }

        try
        {
            var news = await _articleService.GetArticlesByCity(city);
            return Ok(news);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving news: {ex.Message}");
        }
    }
}


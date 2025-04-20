using Microsoft.AspNetCore.Mvc;
using WeatherNewsAPI.SearchHistory.Interfaces;
using WeatherNewsAPI.SearchHistory.Models;

namespace WeatherNewsAPI.SearchHistory.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchHistoryController : ControllerBase
{
    private readonly ISearchHistoryService _searchHistoryService;

    public SearchHistoryController(ISearchHistoryService searchHistoryService)
    {
        _searchHistoryService = searchHistoryService;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<HistoryRecord>>> GetAll()
    {
        var history = await _searchHistoryService.GetAll();
        return Ok(history);
    }

    [HttpGet("city/{city}")]
    public async Task<ActionResult<IEnumerable<HistoryRecord>>> GetByCity(string city)
    {
        var history = await _searchHistoryService.GetByCity(city);
        return Ok(history);
    }

    [HttpGet("type/{type}")]
    public async Task<ActionResult<IEnumerable<HistoryRecord>>> GetByType(string type)
    {
        var history = await _searchHistoryService.GetByType(type);
        return Ok(history);
    }

    [HttpPost]
    public async Task<IActionResult> AddEntry([FromBody] HistoryRecord entry)
    {
        await _searchHistoryService.AddEntry(entry);
        return CreatedAtAction(nameof(GetByCity), new { city = entry.City }, entry);
    }
}

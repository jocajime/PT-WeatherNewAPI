using Microsoft.AspNetCore.Mvc;
using WeatherNewsAPI.SearchHistory.Interfaces;
using WeatherNewsAPI.SearchHistory.Models;

namespace WeatherNewsAPI.SearchHistory.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con el historial de búsqueda.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SearchHistoryController : ControllerBase
{
    private readonly ISearchHistoryService _searchHistoryService;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SearchHistoryController"/>.
    /// </summary>
    /// <param name="searchHistoryService">Servicio para gestionar el historial de búsqueda.</param>
    public SearchHistoryController(ISearchHistoryService searchHistoryService)
    {
        _searchHistoryService = searchHistoryService;
    }

    /// <summary>
    /// Obtiene todo el historial de búsqueda.
    /// </summary>
    /// <returns>
    /// Una lista de registros del historial de búsqueda.
    /// Devuelve un código de estado 200 si la operación es exitosa.
    /// </returns>
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<HistoryRecord>>> GetAll()
    {
        var history = await _searchHistoryService.GetAll();
        return Ok(history);
    }

    /// <summary>
    /// Obtiene el historial de búsqueda filtrado por ciudad.
    /// </summary>
    /// <param name="city">El nombre de la ciudad para filtrar el historial.</param>
    /// <returns>
    /// Una lista de registros del historial relacionados con la ciudad especificada.
    /// Devuelve un código de estado 200 si la operación es exitosa.
    /// </returns>
    [HttpGet("city/{city}")]
    public async Task<ActionResult<IEnumerable<HistoryRecord>>> GetByCity(string city)
    {
        var history = await _searchHistoryService.GetByCity(city);
        return Ok(history);
    }

    /// <summary>
    /// Obtiene el historial de búsqueda filtrado por tipo.
    /// </summary>
    /// <param name="type">El tipo de búsqueda para filtrar el historial.</param>
    /// <returns>
    /// Una lista de registros del historial relacionados con el tipo especificado.
    /// Devuelve un código de estado 200 si la operación es exitosa.
    /// </returns>
    [HttpGet("type/{type}")]
    public async Task<ActionResult<IEnumerable<HistoryRecord>>> GetByType(string type)
    {
        var history = await _searchHistoryService.GetByType(type);
        return Ok(history);
    }

    /// <summary>
    /// Agrega un nuevo registro al historial de búsqueda.
    /// </summary>
    /// <param name="entry">El registro del historial que se va a agregar.</param>
    /// <returns>
    /// Un código de estado 201 si el registro se crea correctamente, junto con la ubicación del recurso creado.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> AddEntry([FromBody] HistoryRecord entry)
    {
        await _searchHistoryService.AddEntry(entry);
        return CreatedAtAction(nameof(GetByCity), new { city = entry.City }, entry);
    }
}

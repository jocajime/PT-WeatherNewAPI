using WeatherNewsAPI.SearchHistory.Models;

namespace WeatherNewsAPI.SearchHistory.Interfaces;

/// <summary>
/// Define la interfaz para el servicio de gestión del historial de búsqueda.
/// </summary>
public interface ISearchHistoryService
{
    /// <summary>
    /// Agrega un nuevo registro al historial de búsqueda.
    /// </summary>
    /// <param name="entry">El registro del historial que se va a agregar.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    Task AddEntry(HistoryRecord entry);

    /// <summary>
    /// Obtiene todos los registros del historial de búsqueda.
    /// </summary>
    /// <returns>
    /// Una tarea que representa la operación asincrónica. El resultado contiene una lista de todos los registros del historial.
    /// </returns>
    Task<IEnumerable<HistoryRecord>> GetAll();

    /// <summary>
    /// Obtiene los registros del historial de búsqueda filtrados por ciudad.
    /// </summary>
    /// <param name="city">El nombre de la ciudad para filtrar los registros del historial.</param>
    /// <returns>
    /// Una tarea que representa la operación asincrónica. El resultado contiene una lista de registros relacionados con la ciudad especificada.
    /// </returns>
    Task<IEnumerable<HistoryRecord>> GetByCity(string city);

    /// <summary>
    /// Obtiene los registros del historial de búsqueda filtrados por tipo.
    /// </summary>
    /// <param name="type">El tipo de búsqueda para filtrar los registros del historial.</param>
    /// <returns>
    /// Una tarea que representa la operación asincrónica. El resultado contiene una lista de registros relacionados con el tipo especificado.
    /// </returns>
    Task<IEnumerable<HistoryRecord>> GetByType(string type);
}

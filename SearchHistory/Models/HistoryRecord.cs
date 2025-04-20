using System;

namespace WeatherNewsAPI.SearchHistory.Models;

/// <summary>
/// Representa un registro del historial de búsqueda, que incluye información sobre la ciudad,
/// el tipo de búsqueda y la fecha en que se realizó.
/// </summary>
public class HistoryRecord
{
    /// <summary>
    /// Obtiene o establece el identificador único del registro del historial.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Obtiene o establece el nombre de la ciudad asociada con la búsqueda.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Obtiene o establece el tipo de búsqueda realizada.
    /// Puede ser "news" para noticias o "weather" para clima.
    /// </summary>
    public string SearchType { get; set; } = string.Empty;

    /// <summary>
    /// Obtiene o establece la fecha y hora en que se realizó la búsqueda.
    /// Se almacena en formato UTC.
    /// </summary>
    public DateTime SearchDate { get; set; } = DateTime.UtcNow;
}

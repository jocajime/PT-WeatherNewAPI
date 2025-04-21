using System;

namespace WeatherNewsWeb.Models;

/// <summary>
/// Representa el historial de búsquedas realizadas por los usuarios.
/// </summary>
public class SearchHistoryModel
{
    /// <summary>
    /// Identificador único del historial de búsqueda.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Ciudad asociada a la búsqueda.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Tipo de búsqueda realizada (por ejemplo, clima o noticias).
    /// </summary>
    public string SearchType { get; set; }

    /// <summary>
    /// Fecha y hora en que se realizó la búsqueda.
    /// </summary>
    public DateTime SearchDate { get; set; }

    /// <summary>
    /// Número de veces que se ha buscado esta ciudad.
    /// </summary>
    public int SearchCount { get; set; }
}

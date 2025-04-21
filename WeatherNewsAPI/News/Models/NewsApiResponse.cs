namespace WeatherNewsAPI.News.Models;

/// <summary>
/// Representa la respuesta de la API de noticias, que incluye el estado de la solicitud,
/// el número total de resultados y una lista de artículos.
/// </summary>
public class NewsApiResponse
{
    /// <summary>
    /// Obtiene o establece el estado de la respuesta de la API.
    /// Por ejemplo, "ok" si la solicitud fue exitosa o "error" si ocurrió un problema.
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Obtiene o establece el número total de resultados devueltos por la API.
    /// </summary>
    public int TotalResults { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de artículos devueltos por la API.
    /// </summary>
    public List<Article>? Articles { get; set; }
}

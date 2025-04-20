namespace WeatherNewsAPI.News.Models;

/// <summary>
/// Representa la fuente de un artículo de noticias, incluyendo su identificador y nombre.
/// </summary>
public class Source
{
    /// <summary>
    /// Obtiene o establece el identificador único de la fuente.
    /// Puede ser <c>null</c> si no se proporciona un identificador.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre de la fuente.
    /// </summary>
    public string? Name { get; set; }
}


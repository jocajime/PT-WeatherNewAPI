namespace WeatherNewsAPI.News.Models;

/// <summary>
/// Representa un artículo de noticias con información relevante como fuente, autor, título, descripción, URL, y más.
/// </summary>
public class Article
{
    /// <summary>
    /// Obtiene o establece la fuente del artículo de noticias.
    /// </summary>
    public Source? Source { get; set; }

    /// <summary>
    /// Obtiene o establece el autor del artículo de noticias.
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// Obtiene o establece el título del artículo de noticias.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Obtiene o establece una breve descripción del artículo de noticias.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Obtiene o establece la URL del artículo de noticias.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Obtiene o establece la URL de la imagen asociada al artículo de noticias.
    /// </summary>
    public string? UrlToImage { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha y hora de publicación del artículo de noticias.
    /// </summary>
    public DateTime? PublishedAt { get; set; }

    /// <summary>
    /// Obtiene o establece el contenido completo del artículo de noticias.
    /// </summary>
    public string? Content { get; set; }
}


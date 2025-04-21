namespace WeatherNewsWeb.Models;

/// <summary>
/// Representa un modelo de noticia con información relevante.
/// </summary>
public class NewsModel
{
    /// <summary>
    /// Fuente de la noticia.
    /// </summary>
    public SourceModel Source { get; set; }

    /// <summary>
    /// Autor de la noticia.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Título de la noticia.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Descripción breve de la noticia.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// URL del artículo completo.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// URL de la imagen asociada a la noticia.
    /// </summary>
    public string UrlToImage { get; set; }

    /// <summary>
    /// Fecha y hora de publicación de la noticia.
    /// </summary>
    public DateTime PublishedAt { get; set; }

    /// <summary>
    /// Contenido completo de la noticia.
    /// </summary>
    public string Content { get; set; }
}

/// <summary>
/// Representa la fuente de una noticia.
/// </summary>
public class SourceModel
{
    /// <summary>
    /// Identificador único de la fuente.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Nombre de la fuente.
    /// </summary>
    public string Name { get; set; }
}

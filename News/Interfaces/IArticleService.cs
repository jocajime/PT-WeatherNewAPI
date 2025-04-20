namespace WeatherNewsAPI.News.Interfaces;
using WeatherNewsAPI.News.Models;

/// <summary>
/// Define la interfaz para el servicio de gestión de artículos de noticias.
/// </summary>
public interface IArticleService
{
    /// <summary>
    /// Obtiene una lista de artículos de noticias relacionados con una ciudad específica.
    /// </summary>
    /// <param name="city">El nombre de la ciudad para buscar artículos de noticias.</param>
    /// <returns>
    /// Una tarea que representa la operación asincrónica. El resultado contiene una lista de artículos de noticias
    /// relacionados con la ciudad especificada, o <c>null</c> si no se encuentran artículos.
    /// </returns>
    Task<List<Article>?> GetArticlesByCity(string city);
}

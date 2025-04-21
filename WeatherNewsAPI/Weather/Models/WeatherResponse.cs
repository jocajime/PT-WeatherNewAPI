namespace WeatherNewsAPI.Weather.Models;

/// <summary>
/// Representa la respuesta procesada con información del clima para una ciudad específica.
/// Incluye detalles como la temperatura, descripción del clima, humedad, velocidad del viento y fecha.
/// </summary>
public class WeatherResponse
{
    /// <summary>
    /// Obtiene o establece el nombre de la ciudad para la cual se proporciona la información del clima.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Obtiene o establece la temperatura en grados Celsius.
    /// </summary>
    public float Temperature { get; set; }

    /// <summary>
    /// Obtiene o establece una descripción del clima (por ejemplo, "cielo despejado").
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Obtiene o establece el porcentaje de humedad.
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Obtiene o establece la velocidad del viento en metros por segundo.
    /// </summary>
    public float WindSpeed { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha y hora de la información del clima.
    /// </summary>
    public DateTime Date { get; set; }
}

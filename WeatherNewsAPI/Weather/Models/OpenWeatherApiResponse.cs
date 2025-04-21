namespace WeatherNewsAPI.Weather.Models;

/// <summary>
/// Representa la respuesta de la API de OpenWeather, que incluye información sobre el clima,
/// la temperatura, el viento y otros datos relacionados con una ubicación específica.
/// </summary>
public class OpenWeatherApiResponse
{
    /// <summary>
    /// Obtiene o establece los datos principales del clima, como la temperatura y la humedad.
    /// </summary>
    public Main? Main { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de condiciones climáticas, como descripciones del clima.
    /// </summary>
    public List<Weather>? Weather { get; set; }

    /// <summary>
    /// Obtiene o establece los datos del viento, como la velocidad.
    /// </summary>
    public Wind? Wind { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre de la ubicación (ciudad).
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Obtiene o establece la marca de tiempo (Unix) de los datos climáticos.
    /// </summary>
    public long Dt { get; set; }
}

/// <summary>
/// Representa los datos principales del clima, como la temperatura y la humedad.
/// </summary>
public class Main
{
    /// <summary>
    /// Obtiene o establece la temperatura en grados Kelvin.
    /// </summary>
    public float Temp { get; set; }

    /// <summary>
    /// Obtiene o establece el porcentaje de humedad.
    /// </summary>
    public int Humidity { get; set; }
}

/// <summary>
/// Representa una condición climática, como una descripción del clima.
/// </summary>
public class Weather
{
    /// <summary>
    /// Obtiene o establece la descripción del clima (por ejemplo, "cielo despejado").
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// Representa los datos del viento, como la velocidad.
/// </summary>
public class Wind
{
    /// <summary>
    /// Obtiene o establece la velocidad del viento en metros por segundo.
    /// </summary>
    public float Speed { get; set; }
}

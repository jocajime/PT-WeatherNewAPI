using System;

namespace WeatherNewsWeb.Models;

/// <summary>
/// Representa la información del clima para una ciudad específica.
/// </summary>
public class WeatherInfoModel
{
    /// <summary>
    /// Nombre de la ciudad para la cual se proporciona la información del clima.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Temperatura actual en la ciudad (en grados Celsius).
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    /// Descripción breve del clima (por ejemplo, "soleado", "nublado").
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Porcentaje de humedad en la ciudad.
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Velocidad del viento en la ciudad (en kilómetros por hora).
    /// </summary>
    public double WindSpeed { get; set; }

    /// <summary>
    /// Fecha y hora de la información del clima.
    /// </summary>
    public DateTime Date { get; set; }
}

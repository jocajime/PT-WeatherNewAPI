namespace WeatherNewsAPI.Weather.Models;

public class WeatherResponse
{
    public string City { get; set; } = string.Empty;
    public float Temperature { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Humidity { get; set; }
    public float WindSpeed { get; set; }
    public DateTime Date { get; set; }
}

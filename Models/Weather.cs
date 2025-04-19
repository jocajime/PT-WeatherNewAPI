namespace WeatherNewsAPI.Models;
public class Weather
{
    public string City { get; set; }
    public string Country { get; set; }
    public double Temperature { get; set; }
    public string WeatherCondition { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public DateTime LastUpdated { get; set; }
}

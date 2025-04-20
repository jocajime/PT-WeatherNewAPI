namespace WeatherNewsAPI.Weather.Models;

public class OpenWeatherApiResponse
{
    public Main? Main { get; set; }
    public List<Weather>? Weather { get; set; }
    public Wind? Wind { get; set; }
    public string? Name { get; set; }
    public long Dt { get; set; }
}

public class Main
{
    public float Temp { get; set; }
    public int Humidity { get; set; }
}

public class Weather
{
    public string? Description { get; set; }
}

public class Wind
{
    public float Speed { get; set; }
}

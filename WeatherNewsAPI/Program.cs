using WeatherNewsAPI.News.Services;
using WeatherNewsAPI.News.Interfaces;
using WeatherNewsAPI.Weather.Services;
using WeatherNewsAPI.Weather.Interfaces;
using WeatherNewsAPI.SearchHistory.Services;
using WeatherNewsAPI.SearchHistory.Interfaces;
using Microsoft.EntityFrameworkCore;
using WeatherNewsAPI.Data;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    var port = Environment.GetEnvironmentVariable("PORT");
    if (!string.IsNullOrEmpty(port))
    {
        options.ListenAnyIP(int.Parse(port));
    }
});


builder.Services.AddHttpClient(); // Configura un cliente HTTP para realizar solicitudes externas.
builder.Services.AddScoped<IWeatherService, WeatherService>(); // Servicio para gestionar información del clima.
builder.Services.AddScoped<IArticleService, ArticleService>(); // Servicio para gestionar artículos de noticias.
builder.Services.AddScoped<ISearchHistoryService, SearchHistoryService>(); // Servicio para gestionar el historial de búsqueda.

builder.Services.AddControllers(); // Agrega soporte para controladores de API.

builder.Services.AddEndpointsApiExplorer(); // Habilita la exploración de endpoints para Swagger.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "WeatherNewsAPI",
        Version = "v1",
        Description = "API para gestionar información del clima, noticias y el historial de búsqueda.",
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
}); // Configura Swagger para la documentación de la API.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configura SQL Server como proveedor de base de datos.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en el entorno de desarrollo.
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger.
}

app.UseHttpsRedirection(); // Redirige automáticamente las solicitudes HTTP a HTTPS.

app.UseAuthorization(); // Configura el middleware de autorización.

app.MapControllers(); // Mapea los controladores definidos en la aplicación.


app.Run();

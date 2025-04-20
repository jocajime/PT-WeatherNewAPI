using WeatherNewsAPI.News.Services;
using WeatherNewsAPI.News.Interfaces;
using WeatherNewsAPI.Weather.Services;
using WeatherNewsAPI.Weather.Interfaces;
using WeatherNewsAPI.SearchHistory.Services;
using WeatherNewsAPI.SearchHistory.Interfaces;
using Microsoft.EntityFrameworkCore;
using WeatherNewsAPI.Data;

/// <summary>
/// Punto de entrada principal para la aplicación WeatherNewsAPI.
/// Configura los servicios, middleware y controladores necesarios para la ejecución de la API.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Configuración de servicios para la aplicación.
/// </summary>
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

/// <summary>
/// Configuración de la base de datos utilizando Entity Framework Core.
/// </summary>
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configura SQL Server como proveedor de base de datos.

var app = builder.Build();

/// <summary>
/// Configuración del middleware de la aplicación.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en el entorno de desarrollo.
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger.
}

app.UseHttpsRedirection(); // Redirige automáticamente las solicitudes HTTP a HTTPS.

app.UseAuthorization(); // Configura el middleware de autorización.

app.MapControllers(); // Mapea los controladores definidos en la aplicación.

/// <summary>
/// Inicia la aplicación.
/// </summary>
app.Run();

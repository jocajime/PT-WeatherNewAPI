using WeatherNewsAPI.News.Services;
using WeatherNewsAPI.News.Interfaces;
using WeatherNewsAPI.Weather.Services;
using WeatherNewsAPI.Weather.Interfaces;
using WeatherNewsAPI.SearchHistory.Services;
using WeatherNewsAPI.SearchHistory.Interfaces;
using Microsoft.EntityFrameworkCore;
using WeatherNewsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ISearchHistoryService, SearchHistoryService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

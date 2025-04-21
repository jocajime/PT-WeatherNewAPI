var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configura los servicios necesarios para la aplicación, como Razor Pages.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Configuración del middleware para manejar las solicitudes HTTP.

if (!app.Environment.IsDevelopment())
{
    // Configuración para entornos de producción:
    // - Redirige a una página de error personalizada en caso de excepciones.
    app.UseExceptionHandler("/Error");

    // Habilita HSTS (HTTP Strict Transport Security) para mejorar la seguridad.
    // El valor predeterminado es 30 días, pero puede ajustarse según las necesidades.
    app.UseHsts();
}

// Redirige automáticamente las solicitudes HTTP a HTTPS para mayor seguridad.
app.UseHttpsRedirection();

// Configura el enrutamiento de las solicitudes.
app.UseRouting();

// Middleware para la autorización de usuarios.
// Actualmente no se han configurado políticas específicas.
app.UseAuthorization();

// Mapea los archivos estáticos para que puedan ser servidos directamente desde el servidor.
app.MapStaticAssets();

// Mapea las páginas Razor y permite servir archivos estáticos asociados.
app.MapRazorPages()
   .WithStaticAssets();

// Inicia la aplicación y comienza a escuchar solicitudes.
app.Run();

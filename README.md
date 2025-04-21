# WeatherNews

Aqui encontraras el proyecto **WeatherNews** aplicaion web para ver las noticias y el clima de la ciudad que prefieras, en este repositorio este proyecto esta dividido en:

1. **WeatherNewsAPI**: Una API desarrollada en ASP.NET Core que proporciona información sobre el clima, noticias destacadas y un historial de búsquedas.
2. **WeatherNewsWeb**: Una aplicación web basada en Razor Pages que consume la WeatherNewsAPI para mostrar información del clima, noticias y el historial de búsquedas.

## Estructura del Proyecto

La solución está organizada en los siguientes directorios:

- **WeatherNewsAPI**: Contiene la lógica de backend, controladores, servicios y configuraciones de la API.
- **WeatherNewsWeb**: Incluye las páginas Razor, controladores y recursos estáticos para la interfaz de usuario.

## Requisitos Previos

Antes de comenzar, asegúrate de tener instalados los siguientes componentes:

- **.NET SDK**: Versión 9.0 o superior.
- **SQL Server**: Para la base de datos del historial de búsquedas.
- **Claves de API**:
  - [OpenWeather API](https://openweathermap.org/api) para datos del clima.
  - [NewsAPI](https://newsapi.org/) para noticias destacadas.

## Configuración

### WeatherNewsAPI

1. Configura las claves de API y la cadena de conexión en el archivo `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*",
  "NewsApi": {
    "ApiKey": "TU_API_KEY",
    "BaseUrl": "https://newsapi.org/v2"
  },
  "OpenWeather": {
    "ApiKey": "TU_API_KEY",
    "BaseUrl": "https://api.openweathermap.org/data/2.5"
  },
  "ConnectionStrings": {
    "DefaultConnection": "CONEXION_A_TU_SERVIDOR_SQLSERVER"
  }
}
```

2. Aplica las migraciones de la base de datos:

```bash
dotnet ef database update --project WeatherNewsAPI
```

3. Ejecuta la API:

```bash
dotnet run --project WeatherNewsAPI
```

### WeatherNewsWeb

1. Configura la URL base de la API en el archivo `appsettings.json`:

```json
{
  "ApiBaseUrl": "https://localhost:5001"
}
```

2. Ejecuta la aplicación web:

```bash
dotnet run --project WeatherNewsWeb
```

## Despliegue en Producción

Puedes acceder a la aplicación desplegada en Azure mediante los siguientes enlaces:

- 🌤 **API WeatherNews**: [Visitar](https://weathernews-api-gydqgya4fbergndy.canadacentral-01.azurewebsites.net/swagger)
- 🌐 **Web WeatherNews**: [Visitar](https://weathernews-web-b7frgdenakcfbahd.canadacentral-01.azurewebsites.net)

🔧 Nota: La documentación Swagger de la API ha sido habilitada temporalmente en producción con fines demostrativos. Se recomienda desactivarla después del proceso de evaluación para mantener la seguridad y buenas prácticas.

## Funcionalidades

### WeatherNewsAPI

- 🔍 **Clima**: Obtiene información meteorológica para una ciudad específica.
- 📰 **Noticias**: Recupera noticias destacadas relacionadas con una ciudad.
- 🗂 **Historial de Búsquedas**: Registra y permite consultar las búsquedas realizadas.

### WeatherNewsWeb

- 🔎 **Búsqueda de Clima y Noticias**: Permite ingresar una ciudad y consultar su clima y noticias relacionadas.
- 📜 **Historial de Búsquedas**: Muestra un historial visual de las consultas recientes.
- 💻 **Interfaz Amigable**: Diseño responsivo con Bootstrap y experiencia de usuario mejorada.

## Tecnologías Utilizadas

### Backend

- ASP.NET Core 9.0
- Entity Framework Core
- Swagger para documentación interactiva de la API

### Frontend

- Razor Pages (ASP.NET)
- Bootstrap 5
- jQuery

### Base de Datos

- Microsoft SQL Server

## Pendientes

- [ ] Agregar pruebas unitarias para servicios y controladores.
- [ ] Mejorar el manejo de errores y respuestas de la API.
- [ ] Implementar autenticación y autorización.
- [ ] Documentar más detalles sobre despliegue y configuración avanzada.
- [ ] Optimizar consultas a la base de datos y uso de caché.

## Licencia

Este proyecto está licenciado bajo la **GNU General Public License v3.0**. Consulta el archivo `LICENSE` para más detalles.

## Contacto

Si tienes preguntas, sugerencias o encuentras algún problema, no dudes en abrir un issue o contactar al mantenedor del proyecto.

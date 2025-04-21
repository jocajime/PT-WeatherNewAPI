# WeatherNews

Este repositorio contiene el proyecto **WeatherNews**, una solución multiproyecto que incluye dos aplicaciones principales:

1. **WeatherNewsAPI**: Una API desarrollada en ASP.NET Core que proporciona información sobre el clima, noticias destacadas y un historial de búsquedas.
2. **WeatherNewsWeb**: Una aplicación web basada en Razor Pages que consume la API para mostrar información del clima, noticias y el historial de búsquedas.

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

1. Configura las claves de API en el archivo `appsettings.json`:

```json
"OpenWeather": {
    "ApiKey": "TU_CLAVE_API"
},
"NewsAPI": {
    "ApiKey": "TU_CLAVE_API"
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

1. Configura la URL base de la API en el archivo `appsettings.json` si es necesario:

```json
"ApiBaseUrl": "https://localhost:5001"
```

2. Ejecuta la aplicación web:

```bash
dotnet run --project WeatherNewsWeb
```

## Funcionalidades

### WeatherNewsAPI

- **Clima**: Obtiene información del clima para una ciudad específica.
- **Noticias**: Recupera noticias destacadas relacionadas con una ciudad.
- **Historial de Búsquedas**: Registra y consulta búsquedas realizadas por los usuarios.

### WeatherNewsWeb

- **Búsqueda de Clima y Noticias**: Permite buscar información del clima y noticias para una ciudad.
- **Historial de Búsquedas**: Muestra un historial de búsquedas recientes.
- **Interfaz Amigable**: Diseño responsivo con Bootstrap.

## Tecnologías Utilizadas

### Backend:
- ASP.NET Core 9.0
- Entity Framework Core
- Swagger para documentación de la API

### Frontend:
- Razor Pages
- Bootstrap
- jQuery

### Base de Datos:
- SQL Server

## Pendientes
- [ ] Agregar pruebas unitarias para los servicios y controladores.
- [ ] Mejorar el manejo de errores en la API.
- [ ] Implementar autenticación y autorización.
- [ ] Documentar más detalles sobre la configuración y despliegue.
- [ ] Optimizar el rendimiento de las consultas a la base de datos.

## Contribuciones

¡Las contribuciones son bienvenidas! Si deseas contribuir a este proyecto:

1. Realiza un fork del repositorio.
2. Crea una rama para tus cambios (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza un commit con tus cambios (`git commit -m "Descripción de los cambios"`).
4. Envía un pull request.

## Licencia

Este proyecto está licenciado bajo la **GNU General Public License v3.0**. Consulta el archivo `LICENSE` para más detalles.

## Contacto

Si tienes preguntas o sugerencias, no dudes en abrir un issue o contactar al mantenedor del proyecto.
# ToDoApp

Una aplicación de tareas simple construida con ASP.NET Core 8.0 y Entity Framework Core.

## Características

- ✅ Crear, editar y eliminar tareas
- ✅ Marcar tareas como completadas
- ✅ Interfaz web responsive
- ✅ Base de datos SQLite integrada

## Tecnologías

- **Backend**: ASP.NET Core 8.0
- **Base de datos**: SQLite con Entity Framework Core
- **Frontend**: Razor Pages con Bootstrap
- **Contenedor**: Docker

## Despliegue en Render

### 1. Preparar el proyecto

El proyecto ya está configurado para Render con:
- ✅ Dockerfile válido
- ✅ Configuración de puertos para producción
- ✅ Base de datos SQLite (no requiere configuración externa)
- ✅ Variables de entorno configuradas

### 2. Subir a Render

1. **Crear cuenta en Render**: Ve a [render.com](https://render.com) y crea una cuenta
2. **Conectar repositorio**: Conecta tu repositorio de GitHub/GitLab
3. **Crear nuevo servicio web**:
   - **Name**: `todoapp` (o el nombre que prefieras)
   - **Environment**: `Docker`
   - **Region**: `Oregon` (o la más cercana a ti)
   - **Branch**: `main` (o tu rama principal)
   - **Root Directory**: Dejar vacío (raíz del proyecto)
   - **Build Command**: `docker build -t todoapp .`
   - **Start Command**: `docker run -p 8080:8080 todoapp`

### 3. Variables de entorno

Render configurará automáticamente:
- `PORT`: Puerto del contenedor (8080)
- `ASPNETCORE_ENVIRONMENT`: Production

### 4. Despliegue

- Render detectará automáticamente el Dockerfile
- Construirá la imagen Docker
- Desplegará la aplicación
- La URL estará disponible en: `https://tu-app.onrender.com`

## Desarrollo local

```bash
# Restaurar paquetes
dotnet restore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

## Estructura del proyecto

```
ToDoApp/
├── Data/
│   └── ApplicationDbContext.cs    # Contexto de EF Core
├── Models/
│   └── Tarea.cs                   # Modelo de datos
├── Pages/                         # Razor Pages
├── Dockerfile                     # Configuración Docker
├── render.yaml                    # Configuración Render
└── README.md                      # Este archivo
```

## Solución de problemas

### Error de compilación en Render
Si obtienes errores de compilación:
1. Verifica que el proyecto compile localmente: `dotnet build`
2. Asegúrate de que todos los archivos estén en el repositorio
3. Revisa los logs de build en Render

### Base de datos
- La aplicación usa SQLite que se crea automáticamente
- No se requiere configuración de base de datos externa
- Los datos se almacenan en el contenedor (se pierden al reiniciar)

## Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.

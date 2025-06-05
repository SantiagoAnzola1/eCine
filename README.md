# 🎬 eCine - Sistema de Gestión de Cines

<p align="center">
  | <a href=READMEEN.md>English</a> | 
    <span>Español</span> |
</p>
<br>

## 📝 Descripción General

Bienvenido a **eCine**, una avanzada aplicación web desarrollada con ASP.NET Core para facilitar la gestión de cines, películas, actores y ventas de entradas. Con interfaces intuitivas y servicios backend robustos, eCine ofrece una solución integral para que administradores y personal de cine gestionen todos los aspectos de la operación cinematográfica, desde la programación de funciones hasta el procesamiento de órdenes.

---

## ⚙️ Tecnologías

- **Framework**: ASP.NET Core 6.0
- **ORM**: Entity Framework Core 7.0
- **Base de Datos**: SQL Server
- **Frontend**:
  - MDB 5 (Material Design for Bootstrap)
  - JavaScript
  - CSS
- **Iconografía**: Font Awesome
- **Librerías Cliente**: jQuery

---

## 📂 Estructura del Proyecto

```
eCine/
├── Controllers/
│ ├── ActorsController.cs
│ ├── CinemasController.cs
│ ├── MoviesController.cs
│ ├── OrdersController.cs
│ └── ProducersController.cs
├── Data/
│ ├── AppDbContext.cs
│ ├── AppDbInitializer.cs
│ ├── Base/
│ ├── Cart/
│ ├── Services/
│ └── ViewComponents/
├── Models/
├── Views/
│ ├── Actors/
│ ├── Cinemas/
│ ├── Movies/
│ ├── Orders/
│ └── Shared/
└── wwwroot/
├── css/
├── js/
└── mdb5-free-standard/
```

---

## 📦 Dependencias

### Paquetes NuGet

- `Microsoft.EntityFrameworkCore` (7.0.10)
- `Microsoft.EntityFrameworkCore.SqlServer` (7.0.9)
- `Microsoft.EntityFrameworkCore.Tools` (7.0.9)

### Librerías Frontend

- MDB 5 (Material Design for Bootstrap)
- Font Awesome
- jQuery

---

## 💻 Requisitos del Sistema

- .NET 6.0 SDK
- SQL Server
- Navegador moderno con soporte para JavaScript ES6+

---

## 🚀 Instalación

1. **Clona el repositorio**

   ```bash
   git clone https://github.com/SantiagoAnzola1/eCine.git
   cd eCine
   ```

2. **Restaura las dependencias**

   ```bash
   dotnet restore
   ```

3. **Actualiza la base de datos**

   ```bash
   dotnet ef database update
   ```

4. **Ejecuta la aplicación**

   ```bash
   dotnet run
   ```

---

## 🔧 Inicialización de Datos

Los datos se generan automáticamente mediante `AppDbInitializer.cs` cuando se crea la base de datos por primera vez. Puedes modificar o deshabilitar esta lógica según las necesidades del entorno de producción.

---

## 📐 Implementación Técnica

### 🏛️ Arquitectura

El proyecto utiliza el patrón **MVC (Modelo-Vista-Controlador)** con las siguientes capas:

- **Controladores** — gestionan las solicitudes y el flujo de la aplicación
- **Modelos** — definen las entidades y reglas de negocio
- **Vistas** — páginas Razor basadas en Bootstrap
- **Datos** — contexto de base de datos, seeders y servicios
- **Servicios** — lógica de negocio (ej. carrito de compras, procesamiento de órdenes)

---

## 🎯 Funcionalidades Clave

- 🎥 Gestión de películas (CRUD)
- 👤 Perfiles de actores y productores
- 🏢 Información de cines
- 🛒 Funcionalidad de carrito de compras
- 🧾 Procesamiento de órdenes con confirmación
- 🔍 Búsqueda y filtrado

---

## 🗄️ Esquema de la Base de Datos

Incluye tablas para:

- Películas
- Actores
- Productores
- Cines
- Órdenes
- Ítems del carrito de compras

El manejo de relaciones se realiza con Entity Framework Core y tablas intermedias para relaciones muchos-a-muchos.

---

## 🛠️ Patrones de Diseño

- **Arquitectura MVC**
- **Patrón Repositorio** (`EntityBaseRepository<T>`)
- **Patrón Servicio** (lógica separada en servicios)
- **Inyección de Dependencias** configurada en `Program.cs`

---

## 👨‍💻 Créditos

- **Autor**: Santiago Anzola Alvarez
- ✉️ santiag.anzola1@gmail.com
- 💻 [GitHub: SantiagoAnzola1](https://github.com/SantiagoAnzola1)

---

## 📄 Licencia

Este proyecto está licenciado bajo la [Licencia MIT](https://opensource.org/licenses/MIT).

---

> _¡Disfruta gestionando tu cine con eCine!_ 🎟️🍿

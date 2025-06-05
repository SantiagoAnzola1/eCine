# 🎬 eCine - Movie Theater Management System

<p align="center">
  | <span>English</span> | 
    <a href=README.md>Español</a> |
</p>
<br>

## 📝 Overview

Welcome to **eCine**, an advanced ASP.NET Core web application designed to streamline the management of movie theaters, films, actors, and ticket sales. With user-friendly interfaces and robust backend services, eCine provides a complete solution for cinema administrators and staff to handle all aspects of movie operations, from scheduling screenings to processing orders.

---

## ⚙️ Technologies

- **Framework**: ASP.NET Core 6.0
- **ORM**: Entity Framework Core 7.0
- **Database**: SQL Server
- **Frontend**:
  - MDB 5 (Material Design for Bootstrap)
  - JavaScript
  - CSS
- **Iconography**: Font Awesome
- **Client-Side Libraries**: jQuery

---

## 📂 Project Structure

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

## 📦 Dependencies

### NuGet Packages

- `Microsoft.EntityFrameworkCore` (7.0.10)
- `Microsoft.EntityFrameworkCore.SqlServer` (7.0.9)
- `Microsoft.EntityFrameworkCore.Tools` (7.0.9)

### Frontend Libraries

- MDB 5 (Material Design for Bootstrap)
- Font Awesome
- jQuery

---

## 💻 System Requirements

- .NET 6.0 SDK
- SQL Server
- Modern browser with ES6+ JavaScript support

---

## 🚀 Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/SantiagoAnzola1/eCine.git
   cd eCine
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Update the database**

   ```bash
   dotnet ef database update
   ```

4. **Run the application**

   ```bash
   dotnet run
   ```

---

## 🔧 Data Initialization

Data is seeded via `AppDbInitializer.cs` when the database is first created. You can modify or disable this logic as needed for production environments.

---

## 📐 Technical Implementation

### 🏛️ Architecture

The project uses the **MVC (Model-View-Controller)** pattern with these layers:

- **Controllers** — handle user requests and application flow
- **Models** — define entities and data rules
- **Views** — Razor pages using Bootstrap-based components
- **Data** — database context, seeding, and services
- **Services** — business logic (e.g., shopping cart, order processing)

---

## 🎯 Key Features

- 🎥 Movie CRUD (Create, Read, Update, Delete)
- 👤 Actor and Producer profiles
- 🏢 Cinema information
- 🛒 Shopping cart functionality
- 🧾 Order processing with confirmation
- 🔍 Search and filter capabilities

---

## 🗄️ Database Schema

Includes tables for:

- Movies
- Actors
- Producers
- Cinemas
- Orders
- Shopping Cart Items

Relational data is handled via Entity Framework Core with junction tables for many-to-many relationships.

---

## 🛠️ Design Patterns

- **MVC Architecture**
- **Repository Pattern** (`EntityBaseRepository<T>`)
- **Service Pattern** (logic separated into services)
- **Dependency Injection** configured in `Program.cs`

---

## 👨‍💻 Credits

- **Author**: Santiago Anzola Alvarez
- ✉️ santiag.anzola1@gmail.com
- 💻 [GitHub: SantiagoAnzola1](https://github.com/SantiagoAnzola1)

---

## 📄 License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

---

> _Enjoy managing your cinema operations with eCine!_ 🎟️🍿

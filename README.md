# 🎬 MvcMovie

Small ASP.NET Core MVC application to manage a list of movies.

> ✅ Educational project to learn MVC, Razor Views, EF Core, CRUD, validations, and migrations.

---

## 📌 Features
- ✅ List, search, and filter movies  
- ✅ Create, edit, and delete movies  
- ✅ Razor Views (MVC pattern)  
- ✅ EF Core with Migrations & DataAnnotations  
- ✅ Optional database seeding  

---

## 🛠️ Technologies Used
- .NET **9**
- C# **13**
- ASP.NET Core **MVC (Razor Views)**
- Entity Framework **Core**

---

## ✅ Requirements
- .NET 9 SDK  
- (Optional) SQL Server / SQLite / other EF Core provider (configured in `appsettings.json`)  
- (Optional) EF Core CLI Tools:
  ```bash
  dotnet tool install --global dotnet-ef


## 🚀 Getting Started
1️⃣ Clone the repository
	`git clone <repository-url>`
	`cd MvcMovie`


2️⃣ Restore dependencies
   `dotnet restore`

3️⃣ Build the project
   `dotnet build`

4️⃣ Apply migrations & create the database
   `dotnet ef database update`

  Note: Migrations are located in the `Migrations/` folder. If you need to create a new migration:
   `dotnet ef migrations add MigrationName`

5️⃣ Run the application
   `dotnet run`

## ✅ Open in browser
   `https://localhost:5001` (or the URL shown in the console) `dotnet run`.

## 🌱 Database Seeding
The project includes `Models/SeedData.cs`, which inserts sample data if the database is empty. Make sure the seed logic is executed from `Program.cs` or manually run the seed code during initialization.

## 🔗 Main Routes
- `/Movies` — Movie list with search and filter by genre
- `/Movies/Create` — Page to create a new movie
- `/Movies/Edit/{id}` — Edit an existing movie
- `/Movies/Delete/{id}` — Delete a movie
- `/` — Home page

## 👨‍💻 Development Notes
- Open the project in Visual Studio, VS Code, Rider, or any compatible IDE
- Run and debug using `dotnet run` or the IDE
- Modify models in `Models/`
- Keep EF Core migrations in sync with model changes

## ✍️ Created by

Nikol Velasquez
# 📲 Multitier WPF Architecture Application

## Contents

1. [Before we start](#before-we-start)
2. [IDEs and plugins used](#ides-and-frameworks-used)
3. [Architecture](#architecture)
4. [DB model](#db-model)

## Before we start

![Main Window](https://i.imgur.com/ygESUiM.jpg)

This application is developed with **DotNet Lead** [guide](http://www.dotnetlead.com/wpf-master-detail/application-and-source-code) as a part of *Software Development* course at [Irkutsk National Research Techincal University](http://www.istu.edu/eng/).

## IDEs and Frameworks used

**IDEs and plugins:**
- Visual Studio 2017 Community Edition [ [download](https://visualstudio.microsoft.com/vs/community/) ]
- JetBrains Reshaper Ultimate [ [download](https://www.jetbrains.com/resharper/) ]

**Frameworks:**
- Entity Framework Core 6 (for SQLite)
- Microsoft Unity
- Extended WPF Toolkit™ [ [link](https://github.com/xceedsoftware/wpftoolkit) ]

Frameworks are available via NuGET Package Manager.

## Architecture

![Multitier architecture](https://i.imgur.com/ONsYWpp.png)

Application is based on multitier architecture:
- UI Layer
- Service Layer
- Business Layer
- Data Access Layer

## DB model

![DB model](https://i.imgur.com/EgYnDAK.png)

I used **Entity Framework Core** and **Code First** approach to create model as shown above. Here's my `DbContext` with `OnConfiguring()` method:
```CSharp
public ResDbContext()
{
    Batteries.Init();
    Database.EnsureCreated();
}
```
It's neccessary to use `Batteries.Init()` for EF Core.
```CSharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Researchers.db" };
    var connectionString = connectionStringBuilder.ToString();
    var connection = new SqliteConnection(connectionString);
    optionsBuilder.UseSqlite(connection);
}
```
Comparing to Entity Framework you don't have to modify config files for connection string so you basically just use `OnConfiguring()` method for it.

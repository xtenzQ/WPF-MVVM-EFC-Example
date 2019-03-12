## 📲 MVVM + Entity Framework Core + Dependency Injection Example App

## Contents

1. [Before we start](#before-we-start)
2. [IDEs and plugins used](#ides-and-frameworks-used)
3. [Architecture](#architecture)

## Before we start

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

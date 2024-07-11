
# Movies On The Cheap

MoviesOnTheCheap is a project built using React for the client UI and ASP.NET for the backend. This application allows users to easily get details of movies and includes admin functionality for managing movie data. The backend and Admin UI is written in C#, and the Customer User Interface is created using React.

## Features

- User-friendly interface to browse and search for movies
- Admin functionality to add, update, and delete movie, Actors details
- Responsive design for a seamless experience across devices



## Requirements

- Node.js
- .NET Core SDK
- SQL Server (or any other compatible database)

## Installation

1. Clone the repository:

```bash
git clone https://github.com/DShubhamBhardwaj/MoviesOnTheCheap.git
cd MoviesOnTheCheap

```

2. Set up the backend:

- Navigate to the project root directory.
- Update the connection string in appsettings.json.
- Run the following commands

```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

3. Set up the frontend:

- Navigate to the ClientApp directory.
- Run the following commands:


```bash
npm install
npm start
```


## Project Structure

- ClientApp/: Contains the React client application.
- Controllers/: ASP.NET controllers for handling API requests.
- Data/: Contains database context and configuration.
- Migrations/: Entity Framework migrations for database schema.
- Models/: Data models representing movie entities.
- Repository/: Repository pattern for data access.
- ViewModels/: View models for data transfer between frontend - and backend.
- Views/: Razor views for server-side rendering.
- wwwroot/: Static files for the ASP.NET application.
## Usage

1. Start the backend server:

```bash
dotnet run

```

2. Start the frontend server:
```bash
npm start

```


3. Open your browser and navigate to http://localhost:3000 to access the application.


## Screenshots
- Landing Page\
![Landing Page](https://github.com/DShubhamBhardwaj/MoviesOnTheCheap/blob/master/Screenshots/LandingPage.png)
- Admin UI\
![Admin UI](https://github.com/DShubhamBhardwaj/MoviesOnTheCheap/blob/master/Screenshots/AdminView.png)
- Movies Input screen\
![Input Screen](https://github.com/DShubhamBhardwaj/MoviesOnTheCheap/blob/master/Screenshots/NewMovieDetails.png)




## Acknowledgements

 - [React](https://reactjs.org/)
 - [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)

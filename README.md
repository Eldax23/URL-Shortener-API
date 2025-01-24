# URL Shortener API

This project is a URL shortener API built with ASP.NET Core. The API takes a long URL and generates a shortened version. Users can access the shortened URL, and the API will redirect them to the original URL.

## Features
- Shorten long URLs.
- Validate URL format.
- Redirect from shortened URLs to original URLs.
- Uses Entity Framework Core with SQL Server for data persistence.

## Requirements
- .NET 7 or later
- SQL Server
- Postman or similar tool for testing API endpoints

## Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/Eldax23/URL-Shortener-API.git
cd urlShortnerApp
```

### 2. Configure the Database
Update the `appsettings.json` file with your database connection string:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=UrlShortener;Trusted_Connection=True;"
}
```

### 3. Install Dependencies
```bash
dotnet restore
```

### 4. Apply Migrations
Generate and apply the database migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Run the Application
Start the application:
```bash
dotnet run
```
The API will be available at `http://localhost:5235`.

## Endpoints

### 1. Shorten URL
**POST** `/shorten`

**Request Body:**
```json
{
    "url": "https://www.facebook.com/"
}
```

**Response:**
```json
{
    "originalUrl": "https://www.facebook.com/",
    "shortUrl": "http://localhost:5235/a1b2c3d4"
}
```

### 2. Redirect to Original URL
**GET** `/{shortUrl}`

- Example: `http://localhost:5235/a1b2c3d4`

If the short URL exists, the API redirects to the original URL. If not, it returns a `404 Not Found` response.

# ZooManagament

## Introduction
This is the API for the Zoo Manangement Application.
All of the endpoints are CRUD like (endpoints to search animal by id, search animals by species and create a new animal)

The application is written in C# with .NET Core, and uses ASP.NET Core, Entity Framework Core and a SQLite Database.

## Getting started
dotnet run

Entity Framework will automatically generate the database for you, and it is populated in code (see Data).
If you need to trigger the database to be recreated, the easiest way is just to delete the `ZooManagement.db` file.

<!-- Use Postman to run the APIs using the below hostaddress. -->

HostAddress = http://localhost:5067

This application uses Swagger (Open API), to access the local host using swagger use http://localhost:5067/swagger
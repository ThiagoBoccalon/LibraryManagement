## LibraryManagement is a manager of libraries.

### 1. About the project

LibraryManagment API is a project developed as a personal project. The project aims to manage users, books and loans. Users can be common users (someone go to the library to loan any book) or a staff from the library. Common users can loan any books and it have to return within 14 days if the user fails to return, a penalty of £0.25 per day will applied. Staff user is someone responsable for register books of the library and to allow the loan.

### 2. Functionalities

- Users Login and register them.

- CRUD Books and Loans

- I will build e a microservice responsable by manage the payment.

### 3. Technologies used

- .NET 8

- Entity Framework Core

- SQL Server

- C#

- xUnit

- Authentication e Authorization with JWT Bearer

### 4. Architecture and patterns applied

- Clean Architecture

- CQRS

- Repository

- Fluent Validation

- Repository Pattern

- UnitTests

### 5. How do you get started?

**5.1. Prerequisites\*\***

- .NET 8 SDK

- Visual Studio Community 2022 or VS Code

- SQL Server Management Studio 20

- Entity Framework Core installed

**5.2. Running**

- Downloading this repository using git

- git clone https://github.com/ThiagoBoccalon/LibraryManagement.git

- Open project/solution on Visual Studio

- Make sure SQL Server is opened

- Applying migrations - `cd LibraryManagement\LibraryManagement.Infrastructure>` - `LibraryManagement\LibraryManagement.Infrastructure>dotnet ef database update -s ../LibraryManagement.API/LibraryManagement.API.csproj`

- F5 for running

### 6. Sreem shoots

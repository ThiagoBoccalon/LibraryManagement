## LibraryManagement is a manager of libraries.

### 1. About the project

LibraryManagment API is a project developed as a personal project. The project aims to manage users, books, and loans. Users can be common users (someone who goes to the library to borrow any book) or library staff. Common users can borrow books, but they must return them within 14 days. If the user fails to return them, a penalty of £0.25 per day will be applied. A staff user is someone responsible for registering books in the library and allowing loans.

### 2. Functionalities

- Users Login and register them.

- CRUD Books and Loans

- Microservice responsible for managing the payment.

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

<img width="542" alt="librarymanagementAPI" src="https://github.com/user-attachments/assets/be617963-489a-4bb8-96d3-48348a28c3cc"> ![librarymanagementAPI_2](https://github.com/user-attachments/assets/13229f78-9480-4189-8f8a-b0946f9037c2)

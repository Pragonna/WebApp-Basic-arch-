# WebApp Basic Architecture

## Overview
**WebApp Basic Architecture** is a foundational project that demonstrates a well-structured 6-layer architecture for a .NET-based web application. The architecture is designed to handle authentication, business logic, persistence, and more, with a strong separation of concerns. This project offers user authentication, role-based access control, and CRUD operations based on user roles.

## Layers Overview

### 1. **Core.Application**
   - **Purpose:** Serves as the heart of the application logic.
   - **Responsibilities:**
     - Provides interfaces for business logic.
     - Contains service abstractions and repositories.
     - Facilitates communication between the presentation and business layers.
   - **Examples:**
     - Service contracts (e.g., `IUserService`, `IProductService`).
     - Repository interfaces (e.g., `IRepository<T>`).

### 2. **Core.Domain**
   - **Purpose:** Defines the core domain entities and their relationships.
   - **Responsibilities:**
     - Encapsulates business domain models.
     - Defines the properties, methods, and validation logic for domain entities.
   - **Examples:**
     - Entities like `User`, `Role`, `Product`.

### 3. **Core.Business**
   - **Purpose:** Implements the actual business rules and validation logic.
   - **Responsibilities:**
     - Ensures business requirements are met through validations and computations.
     - Implements services defined in the `Core.Application` layer.
   - **Examples:**
     - User registration, role-based data validation, and CRUD operations.

### 4. **Core.Security**
   - **Purpose:** Manages authentication and authorization.
   - **Responsibilities:**
     - Handles JWT authentication for secure API access.
     - Implements user login, registration, and token generation.
     - Ensures role-based access control (RBAC).
   - **Examples:**
     - User authentication logic, JWT handling, and role verification.

### 5. **Core.Persistence**
   - **Purpose:** Manages data persistence and interactions with the database.
   - **Responsibilities:**
     - Contains the DbContext and manages database migrations.
     - Implements repository patterns to abstract the data access logic.
   - **Examples:**
     - Entity Framework DbContext, repository implementations for `User`, `Product`.

### 6. **Presentation.WebAPI**
   - **Purpose:** The API layer that exposes endpoints for external clients.
   - **Responsibilities:**
     - Hosts the controllers for handling HTTP requests.
     - Integrates with the business logic layer to provide data and services to users.
   - **Examples:**
     - Controllers like `AuthController`, `UserController`, `ProductController`.

## Features
- **JWT Authentication:** Secure token-based authentication system.
- **Role-based Authorization:** Enforces access control based on user roles.
- **Layered Architecture:** Clear separation of concerns for better maintainability.

## Getting Started

### Prerequisites
- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Pragonna/WebApp-Basic-arch-.git
   ```

2. **Navigate to the project directory:**
   ```bash
   cd WebApp-Basic-arch
   ```

3. **Restore the dependencies:**
   ```bash
   dotnet restore
   ```

4. **Configure the database:**
   - Update your connection string in `appsettings.json` to point to your SQL Server instance.

5. **Run the database migrations:**
   ```bash
   dotnet ef database update
   ```

6. **Build the solution:**
   ```bash
   dotnet build
   ```

7. **Run the application:**
   ```bash
   dotnet run
   ```

8. **Access the API:**
   - Navigate to `http://localhost:5000` in your browser or use an API client like Postman.

## API Endpoints
- **POST /api/auth/login** - User login with JWT generation.
- **POST /api/auth/register** - New user registration.
- **GET /api/users** - Fetches the list of users (admin access).
- **GET /api/products** - Retrieves product details (role-based access).

## Testing
- Unit tests and integration tests can be added for different layers to ensure system correctness and reliability.
  
## License
This project is licensed under the MIT License.

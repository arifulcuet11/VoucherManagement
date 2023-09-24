# Voucher Management API

This project is a .NET Core API that manages and validates discount vouchers for an e-commerce platform.

## Getting Started

These instructions will help you set up and run the project both with and without Docker.

### Prerequisites

- Docker (with Docker Compose) installed on your system. [Download Docker here](https://www.docker.com/get-started).

### Running the Application with Docker

1. **Clone the repository to your local machine.**

2. **Open a terminal or command prompt and navigate to the project directory.**

3. Use the following command to **build and start the Docker containers**:

   ```bash
   docker-compose up -d
This will build the Docker images and start the containers for both the web application and the MySQL database.
Once the containers are up and running, you can access the API at http://localhost:8080.
### Running the Application without Docker
1. **Update Connection String:**
Open your project's configuration file (e.g., appsettings.json or appsettings.Development.json) and provide the connection string for your MySQL database:

  ```
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Port=3306;Database=voucherDb;User=dbuser;Password=voucher@123;"
   }
 ```
### Stopping the Application

To **stop the application**:

- If using Docker, run:

  ```bash
  docker-compose down
  ```

  ### Additional Information

- The API service is exposed on **port 8080**. You can adjust the port mapping in the `docker-compose.yml` file if needed.

- The MySQL database is exposed on **port 3306**. If you need to connect to it from a client outside the Docker network (or directly when running without Docker), you can use `localhost` and port `3306`.

## API Documentation

The API is documented using Swagger. You can access the Swagger UI by following the link below:
```
http://localhost:8080/swagger/index.html
```
The Swagger documentation provides detailed information about the API endpoints, request parameters, and response formats.


## Command Query Responsibility Segregation (CQRS)

This project follows the CQRS (Command Query Responsibility Segregation) design pattern.

### How CQRS is Implemented

In this project:

- **Commands** are responsible for actions that change the state of the system. For example, creating, updating, or deleting data.

- **Queries** are responsible for retrieving data from the system. They do not modify the state of the system and are used for reading purposes.

By separating commands and queries, we can optimize each path independently. This allows for more efficient handling of both write and read operations.

### When to Use CQRS

CQRS is particularly useful in scenarios where:

- There is complex business logic involved.
- There are high scalability requirements.
- There is a need for independent optimization of read and write operations.

It's important to note that while CQRS can provide benefits in certain scenarios, it can also introduce complexity. It should be applied judiciously based on the specific requirements of the system.

For more detailed information on CQRS, refer to [this resource](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs).






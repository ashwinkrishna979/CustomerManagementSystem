# Pinewood Technologies: Technical Task

Thank you for the opportunity to participate in the selection process for the Development team at Pinewood Technologies. Below, you'll find an overview of my solution to the given task.

## Project Overview

This project is a self-contained solution that adds, edits, and deletes customers using ASP.NET with a Blazor frontend, an ASP.NET API backend, and PostgreSQL for data storage. The project is also containerized using Docker Compose.

## Technologies Used

- **Frontend**: Blazor (ASP.NET)
- **Backend**: ASP.NET Core Web API
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Containerization**: Docker, Docker Compose

## Setup Instructions

### Prerequisites

- Docker installed on your machine
- .NET 6.0 SDK installed on your machine

### Running the Application

1. **Clone the Repository**:

    ```sh
    git clone <your-repository-url>
    cd <your-repository-directory>
    ```

2. **Build and Run with Docker Compose**:

    Ensure Docker is running, then use the following command to start the application:

    ```sh
    docker-compose up --build
    ```

    This will build and run the containers for the Blazor frontend, ASP.NET API backend, and PostgreSQL database.

3. **Access the Application**:

    Once the Docker containers are running, you can access the application in your web browser at:

    ```
    http://localhost:5000
    ```

    The API will be running at:

    ```
    http://localhost:5001
    ```

## Project Structure

- `/Client`: Contains the Blazor frontend project.
- `/Server`: Contains the ASP.NET Core Web API project.
- `/Shared`: Contains shared models and code used by both Client and Server.
- `/Data`: Contains Entity Framework Core DbContext and migration files.
- `docker-compose.yml`: Docker Compose configuration file.

## Database Configuration

The PostgreSQL database is configured in the `docker-compose.yml` file. The connection string is defined in the `appsettings.json` file of the Server project.

## API Endpoints

The following endpoints are available in the API:

- **GET** `/api/customers`: Retrieve all customers.
- **GET** `/api/customers/{id}`: Retrieve a customer by ID.
- **POST** `/api/customers`: Create a new customer.
- **PUT** `/api/customers/{id}`: Update an existing customer.
- **DELETE** `/api/customers/{id}`: Delete a customer.

## Important Notes

- This task focuses on functionality rather than UI/UX design.
- The project includes basic CRUD operations for managing customers.
- Please review the code for more details on the implementation and feel free to ask any questions during the interview.

## Conclusion

Thank you for the opportunity to work on this task. I look forward to discussing my approach and design decisions with you in the interview.

If you have any questions or need further information, please feel free to contact me at [your-email@example.com].

Best regards,

[Your Name]


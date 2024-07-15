# Pinewood Technologies: Technical Task

Thank you for the opportunity to participate in the selection process for the Development team at Pinewood Technologies. Below, you'll find an overview of my solution to the given task.

## Project Overview

This project is a self-contained solution that adds, edits, and deletes customers using ASP.NET with a Blazor frontend, an ASP.NET API backend, and PostgreSQL for data storage. The project is also containerized using Docker Compose.

## Technologies Used

- **Frontend**: Blazor (ASP.NET)
- **Backend**: ASP.NET Core Web API
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Containerization**: Docker

### Prerequisites

- Docker should be installed and running on your machine (https://docs.docker.com/desktop/install/windows-install/)

### Running the Application

1. **Clone the Repository**:

    ```sh
    https://github.com/ashwinkrishna979/CustomerManagementSystem.git
    ```
    open root directory(CustomerManagementSystem) in terminal.

2. **Build and Run with Docker Compose**:

    Ensure Docker is running, then use the following command to start the application:

    ```sh
    docker-compose up --build
    ```

    This will build and run the containers for the web application server, and PostgreSQL database.

3. **Access the Application**:

    Once the Docker containers are running, you can access the application in your web browser at:
    ```
    http://localhost:8080/
    ```

## Project Structure

- `/CMS.Web`: Contains the ASP.NET Blazor frontend project.
- `/CMS.UseCases`: Contains the ASP.NET Core Web API project. Applications use cases and validation logic are written here.
- `/CMS.CoreBusiness`: Contains shared models.
- `/CMS.Data`: Contains Entity Framework Core, DbContext and migration files.
- `/compose.yml`: Docker Compose configuration file.
- `/migration.sh`: Contains Database migration shell script to automate migration on docker-compose.
- /.env : Contains Postgres database connection configuration.

## Database Configuration

- The PostgreSQL database is configured in the `docker-compose.yml` file. The connection string is defined in the `appsettings.json` file and  .env.
- You can you Azure Data Studio or pgAdmin 4 to connect the database for managing it externally.
  The following is a sample query to get customer data from the database:
  ```
  select  "Id"
  ,Name"
  ,"Email"
  ,"Phone"
  from public."Customers"
  LIMIT 1000
  ```

## Conclusion

Thank you for the opportunity to work on this task. I look forward to discussing my approach and design decisions with you in the interview.

If you have any questions or need further information, please feel free to contact me at ashwinkrishna979@gmail.com.


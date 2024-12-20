## i. Setup Instructions

### Prerequisites

Before you can run this project, ensure you have the following installed:

- **.NET 8 SDK**: Download and install the .NET 8 SDK from the official Microsoft site: [Download .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Visual Studio 2022 or later** (optional but recommended for easier development and debugging)
- **SQL Server**
- **Required libraries**: Dependencies should be handled via the project’s `.csproj` files (e.g., Entity Framework, ASP.NET Core).

### Installation Steps

#### 1. Clone the Repository

Clone the repository to your local machine using the following command:

```bash
git clone <repo-url>
```
#### 2. Navigate to the Project Directory

Once the repository is cloned, navigate to the root folder of the project:

```bash
cd <project-folder>
```
#### 3. Restore Dependencies
Restore the dependencies for the solution by running the following command:

```bash
dotnet restore
```
#### 4. Configure Connection String
Modify the connection string in the WebApi project to connect to your database:

Navigate to WebApi > appsettings.json.
Update the "ConnectionStrings" section with your database connection string. For example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-server>;Database=<your-database>;User Id=<your-username>;Password=<your-password>;TrustServerCertificate=True;"
  }
}
```


#### 5. Set Up Multiple Project Startup
To configure multiple projects to start (i.e., both the WebApi and WebApp projects), follow these steps:

- Right-click on the **solution** in **Solution Explorer**.
- Select **Configure Startup Projects**.
- In the dialog that appears, select **Multiple Startup Projects**.
- Set both the **WebApi** and **WebApp** projects to **Start**.


#### 6. Apply Migrations
Need to apply migration for updating database by running the following command:

From **Package Manager Console**

##### 1. Open Package Manager Console:

- Navigate to **Tools > NuGet Package Manager > Package Manager Console**.
##### 2. Set Default Project to Data.SqlServer:

- In the Package Manager Console, select **Data.SqlServer** as the default project.
##### 3. Run the Command:

- Type **Update-Database** and press Enter.
##### 4. Verify the Results:

- Check the console output for confirmation or error messages.


## ii. Project overview and features.
This project is a comprehensive Employee Management System designed to handle the key operations related to managing employee data, their performance reviews, departmental assignments, and optimizing complex queries for large datasets. The system allows organizations to efficiently manage employees, departments, and their performance while providing the ability to search, filter, and generate reports. The application is built using .NET, Entity Framework Core for ORM, and SQL for data management.

The primary features of the system are organized into modules for employee management, departmental assignments, performance reviews, and enhanced querying capabilities. This project can be expanded or integrated with other systems for a complete HR management solution.

### Key Features
#### 1. Employee CRUD Operations
- Create: Add a new employee with essential information such as Name, Email, Phone, Department, Position, and Joining Date.
- Read: List all employees with pagination support for better data management and performance.
- Update: Modify employee details, including personal information and position changes.
- Delete: Soft delete an employee by setting a "Deleted" flag, ensuring data integrity and the ability to restore records if necessary.
#### 2. Department Management
+ Department Entity: A separate entity for managing departments, including fields such as:
  + Department Name
  + Manager (linked to an employee, One-to-One relationship)
  + Budget (numerical value representing the department's allocated budget)
+ Employee-Department Relationship: Employees are assigned to specific departments with a foreign key relationship between the Employee and Department tables.
#### 3. Employee Performance Review
- Performance Reviews: Employees are reviewed quarterly, with reviews storing the following information:
  - EmployeeID: Links to the employee being reviewed.
  - Review Date: The date the review took place.
  - Review Score: A numeric score between 1-10 representing employee performance.
  - Review Notes: Qualitative notes on the employee’s performance.
- One-to-Many Relationship: Each employee can have multiple performance reviews, which are stored in a separate PerformanceReview table linked by the EmployeeID foreign key.
#### 4. Complex Query with Optimization
- Average Performance Score: Implement a query that calculates the average performance score for each department based on employee performance reviews.
  - Optimization: The query is optimized for large datasets, utilizing techniques like indexes, subqueries, and joins to ensure efficient data retrieval.
  - Exclusions: Employees with no performance reviews are excluded from the result.
  - Output: The result will include the department name and the average performance score for that department.
#### 5. Search and Filter Functionality
- Employee Search by Name: Implement full-text search functionality to find employees by their name.
- Department Filter: Filter employees by their department.
- Position Filter: Filter employees based on their position within the organization.
- Performance Score Filter: Filter employees by their performance score range.
- Pagination: All search results are paginated for efficient data loading, ensuring the system can handle large datasets without compromising performance.


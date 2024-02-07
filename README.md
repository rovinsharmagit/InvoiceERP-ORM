----
[![wakatime](https://wakatime.com/badge/user/018b52ca-833c-449a-8a52-a35427011708/project/018d5f9d-f096-4e7a-a47a-a6ef653de923.svg)](https://wakatime.com/badge/user/018b52ca-833c-449a-8a52-a35427011708/project/018d5f9d-f096-4e7a-a47a-a6ef653de923)
----
[![wakatime](https://wakatime.com/badge/github/rovinsharmagit/InvoiceERP--ORM-.svg)](https://wakatime.com/badge/github/rovinsharmagit/InvoiceERP--ORM-)
----

### 🛠 &nbsp;Languages and Tools :

<p align="center">
  <a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=git,bootstrap,cs,css,dotnet,github,js,jquery,visualstudio,vscode" />
  </a>
</p>

----

# InvoiceORM App

This is a C# ASP.NET Core application for managing invoicing using SQL Server as the database backend. The application provides functionalities for managing various aspects of invoicing including customers, suppliers, invoices, payments, and more.

## Features

- **Customer Management**: Allows adding, editing, and deleting customer information.
- **Supplier Management**: Provides functionalities for managing supplier details.
- **Invoice Management**: Allows generating and managing customer invoices and supplier invoices.
- **Payment Management**: Enables tracking payments from customers and payments to suppliers.
- **Employee Management**: Provides features for managing employee information.
- **Financial Year Management**: Allows defining financial years for tracking transactions.
- **User Management**: Provides user authentication and authorization features.

## Database Schema

The application utilizes the following database schema:

- **AccountControl**: Manages account control information.
- **AccountHead**: Manages account head details.
- **AccountSubControl**: Handles sub-controls related to accounts.
- **Branch**: Stores branch details.
- **BranchType**: Manages branch types.
- **Category**: Manages categories for products/services.
- **Company**: Stores company information.
- **Customer**: Manages customer details.
- **CustomerInvoice**: Handles customer invoices.
- **CustomerInvoiceDetail**: Stores details of customer invoices.
- **CustomerPayment**: Manages payments received from customers.
- **Employee**: Manages employee information.
- **FinancialYear**: Handles financial year details.
- **Payroll**: Manages payroll information.
- **Stock**: Stores stock information.
- **Supplier**: Manages supplier details.
- **SupplierInvoice**: Handles supplier invoices.
- **SupplierInvoiceDetail**: Stores details of supplier invoices.
- **SupplierPayment**: Manages payments to suppliers.
- **Transaction**: Manages transaction details.
- **User**: Stores user information.
- **UserType**: Manages user types.

## Setup

1. Clone the repository to your local machine.
2. Open the solution file (`InvoiceERP.sln`) in Visual Studio.
3. Configure the database connection string in `appsettings.json` file.
4. Run the database migrations to create the necessary tables in the database.
5. Build and run the application.

## Technologies Used

- **C#**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**

## Contributors

- [[Rovin Sharma](https://github.com/rovinsharmagit)]

## License

This project is licensed under the [MIT License](LICENSE).

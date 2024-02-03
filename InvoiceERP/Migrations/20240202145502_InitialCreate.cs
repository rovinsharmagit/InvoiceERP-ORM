using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblBranchType",
                columns: table => new
                {
                    BranchTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBranchType", x => x.BranchTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tblCompany",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompany", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "tblUserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tblBranch",
                columns: table => new
                {
                    BranchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchTypeID = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BrchID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBranch", x => x.BranchID);
                    table.ForeignKey(
                        name: "FK_tblBranch_tblBranchType",
                        column: x => x.BranchTypeID,
                        principalTable: "tblBranchType",
                        principalColumn: "BranchTypeID");
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_tblUser_tblUserType",
                        column: x => x.UserTypeID,
                        principalTable: "tblUserType",
                        principalColumn: "UserTypeID");
                });

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<byte[]>(type: "varbinary(300)", maxLength: 300, nullable: false),
                    MonthlySalary = table.Column<double>(type: "float", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_tblEmployee_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblEmployee_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "tblAccountControl",
                columns: table => new
                {
                    AccountControlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    AccountHeadID = table.Column<int>(type: "int", nullable: false),
                    AccountControlName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccountControl", x => x.AccountControlID);
                    table.ForeignKey(
                        name: "FK_tblAccountControl_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblAccountControl_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblAccountControl_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblAccountHead",
                columns: table => new
                {
                    AccountHeadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    AccountHeadName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccountHead", x => x.AccountHeadID);
                    table.ForeignKey(
                        name: "FK_tblAccountHead_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_tblCategory_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblCategory_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblCategory_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customername = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    CustomerContact = table.Column<int>(type: "int", nullable: false),
                    CustomerArea = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CustomerAddress = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_tblCustomer_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblCustomer_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblCustomer_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblFinancialYear",
                columns: table => new
                {
                    FinancialYearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FinancialYear = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinancialYear", x => x.FinancialYearID);
                    table.ForeignKey(
                        name: "FK_tblFinancialYear_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblSupplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SupplierConatctNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SupplierEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSupplier", x => x.SupplierID);
                    table.ForeignKey(
                        name: "FK_tblSupplier_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblSupplier_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblSupplier_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblPayroll",
                columns: table => new
                {
                    PayrollID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    TransferAmount = table.Column<double>(type: "float", nullable: false),
                    PayrollInvoiceNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    SalaryMonth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalaryYear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayroll", x => x.PayrollID);
                    table.ForeignKey(
                        name: "FK_tblPayroll_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPayroll_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblPayroll_tblEmployee",
                        column: x => x.EmployeeID,
                        principalTable: "tblEmployee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPayroll_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblAccountSubControl",
                columns: table => new
                {
                    AccountSubControlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHeadID = table.Column<int>(type: "int", nullable: false),
                    AccountControlID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    AccountSubControlName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccountSubControl", x => x.AccountSubControlID);
                    table.ForeignKey(
                        name: "FK_tblAccountSubControl_tblAccountControl",
                        column: x => x.AccountControlID,
                        principalTable: "tblAccountControl",
                        principalColumn: "AccountControlID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAccountSubControl_tblAccountHead",
                        column: x => x.AccountHeadID,
                        principalTable: "tblAccountHead",
                        principalColumn: "AccountHeadID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAccountSubControl_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblAccountSubControl_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblStock",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SaleUnitPrice = table.Column<double>(type: "float", nullable: false),
                    CurrentPurchaseUnitPrice = table.Column<double>(type: "float", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Manufacture = table.Column<DateTime>(type: "date", nullable: false),
                    StockTreshHoldQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStock", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_tblStock_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblStock_tblCategory",
                        column: x => x.CategoryID,
                        principalTable: "tblCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblStock_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblStock_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerInvoice",
                columns: table => new
                {
                    CustomerInvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerInvoice", x => x.CustomerInvoiceID);
                    table.ForeignKey(
                        name: "FK_tblCustomerInvoice_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblCustomerInvoice_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblCustomerInvoice_tblCustomer",
                        column: x => x.CustomerID,
                        principalTable: "tblCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCustomerInvoice_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblSupplierInvoice",
                columns: table => new
                {
                    SupplierInvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSupplierInvoiceTable", x => x.SupplierInvoiceID);
                    table.ForeignKey(
                        name: "FK_tblSupplierInvoiceTable_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblSupplierInvoiceTable_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblSupplierInvoiceTable_tblSupplier",
                        column: x => x.SupplierID,
                        principalTable: "tblSupplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSupplierInvoice_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblSupplierPayment",
                columns: table => new
                {
                    SupplierPaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    SupplierInvoiceID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    invoiceNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    RemainingBalance = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSupplierPayment", x => x.SupplierPaymentID);
                    table.ForeignKey(
                        name: "FK_tblSupplierPayment_tblSupplier",
                        column: x => x.SupplierID,
                        principalTable: "tblSupplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSupplierPayment_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialYearID = table.Column<int>(type: "int", nullable: false),
                    AccountHeadID = table.Column<int>(type: "int", nullable: false),
                    AccountControlID = table.Column<int>(type: "int", nullable: false),
                    AccountSubControlID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransactionTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransectionTable", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblAccountControl",
                        column: x => x.AccountControlID,
                        principalTable: "tblAccountControl",
                        principalColumn: "AccountControlID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblAccountHead",
                        column: x => x.AccountHeadID,
                        principalTable: "tblAccountHead",
                        principalColumn: "AccountHeadID");
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblFinancialYear",
                        column: x => x.FinancialYearID,
                        principalTable: "tblFinancialYear",
                        principalColumn: "FinancialYearID");
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_tblTransection_tblAccountSubControl",
                        column: x => x.AccountSubControlID,
                        principalTable: "tblAccountSubControl",
                        principalColumn: "AccountSubControlID");
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerInvoiceDetail",
                columns: table => new
                {
                    CustomerInvoiceDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerInvoiceID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SaleQuantity = table.Column<int>(type: "int", nullable: false),
                    SaleUnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerInvoiceDetail", x => x.CustomerInvoiceDetailID);
                    table.ForeignKey(
                        name: "FK_tblCustomerInvoiceDetail_tblCustomerInvoice",
                        column: x => x.CustomerInvoiceID,
                        principalTable: "tblCustomerInvoice",
                        principalColumn: "CustomerInvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCustomerInvoiceDetail_tblStock",
                        column: x => x.ProductID,
                        principalTable: "tblStock",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerPayment",
                columns: table => new
                {
                    CustomerPaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CustomerInvoiceID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    invoiceNo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    RemainingBalance = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomerPayment", x => x.CustomerPaymentID);
                    table.ForeignKey(
                        name: "FK_tblCustomerPayment_tblBranch",
                        column: x => x.BranchID,
                        principalTable: "tblBranch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_tblCustomerPayment_tblCompany",
                        column: x => x.CompanyID,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_tblCustomerPayment_tblCustomerInvoice",
                        column: x => x.CustomerInvoiceID,
                        principalTable: "tblCustomerInvoice",
                        principalColumn: "CustomerInvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCustomerPayment_tblUser",
                        column: x => x.UserID,
                        principalTable: "tblUser",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "tblSupplierInvoiceDetail",
                columns: table => new
                {
                    SupplierInvoiceDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierInvoiceID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    PurchaseQuantity = table.Column<int>(type: "int", nullable: false),
                    purchaseUnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSupplierInvoiceDetailTable", x => x.SupplierInvoiceDetailID);
                    table.ForeignKey(
                        name: "FK_tblSupplierInvoiceDetail_tblStock",
                        column: x => x.ProductID,
                        principalTable: "tblStock",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSupplierInvoiceDetail_tblSupplierInvoice",
                        column: x => x.SupplierInvoiceID,
                        principalTable: "tblSupplierInvoice",
                        principalColumn: "SupplierInvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountControl_BranchID",
                table: "tblAccountControl",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountControl_CompanyID",
                table: "tblAccountControl",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountControl_UserID",
                table: "tblAccountControl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountHead_UserID",
                table: "tblAccountHead",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountSubControl_AccountControlID",
                table: "tblAccountSubControl",
                column: "AccountControlID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountSubControl_AccountHeadID",
                table: "tblAccountSubControl",
                column: "AccountHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountSubControl_BranchID",
                table: "tblAccountSubControl",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAccountSubControl_UserID",
                table: "tblAccountSubControl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblBranch_BranchTypeID",
                table: "tblBranch",
                column: "BranchTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_BranchID",
                table: "tblCategory",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_CompanyID",
                table: "tblCategory",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_UserID",
                table: "tblCategory",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_BranchID",
                table: "tblCustomer",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_CompanyID",
                table: "tblCustomer",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomer_UserID",
                table: "tblCustomer",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerInvoice_BranchID",
                table: "tblCustomerInvoice",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerInvoice_CompanyID",
                table: "tblCustomerInvoice",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerInvoice_CustomerID",
                table: "tblCustomerInvoice",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerInvoice_UserID",
                table: "tblCustomerInvoice",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerInvoiceDetail_CustomerInvoiceID",
                table: "tblCustomerInvoiceDetail",
                column: "CustomerInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerInvoiceDetail_ProductID",
                table: "tblCustomerInvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerPayment_BranchID",
                table: "tblCustomerPayment",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerPayment_CompanyID",
                table: "tblCustomerPayment",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerPayment_CustomerInvoiceID",
                table: "tblCustomerPayment",
                column: "CustomerInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomerPayment_UserID",
                table: "tblCustomerPayment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_BranchID",
                table: "tblEmployee",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_CompanyID",
                table: "tblEmployee",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblFinancialYear_UserID",
                table: "tblFinancialYear",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayroll_BranchID",
                table: "tblPayroll",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayroll_CompanyID",
                table: "tblPayroll",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayroll_EmployeeID",
                table: "tblPayroll",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_tblPayroll_UserID",
                table: "tblPayroll",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStock_BranchID",
                table: "tblStock",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStock_CategoryID",
                table: "tblStock",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStock_CompanyID",
                table: "tblStock",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStock_UserID",
                table: "tblStock",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplier_BranchID",
                table: "tblSupplier",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplier_CompanyID",
                table: "tblSupplier",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplier_UserID",
                table: "tblSupplier",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierInvoice_BranchID",
                table: "tblSupplierInvoice",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierInvoice_CompanyID",
                table: "tblSupplierInvoice",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierInvoice_SupplierID",
                table: "tblSupplierInvoice",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierInvoice_UserID",
                table: "tblSupplierInvoice",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierInvoiceDetail_ProductID",
                table: "tblSupplierInvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierInvoiceDetail_SupplierInvoiceID",
                table: "tblSupplierInvoiceDetail",
                column: "SupplierInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierPayment_SupplierID",
                table: "tblSupplierPayment",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSupplierPayment_UserID",
                table: "tblSupplierPayment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_AccountControlID",
                table: "tblTransaction",
                column: "AccountControlID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_AccountHeadID",
                table: "tblTransaction",
                column: "AccountHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_AccountSubControlID",
                table: "tblTransaction",
                column: "AccountSubControlID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_FinancialYearID",
                table: "tblTransaction",
                column: "FinancialYearID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_UserID",
                table: "tblTransaction",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_UserTypeID",
                table: "tblUser",
                column: "UserTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomerInvoiceDetail");

            migrationBuilder.DropTable(
                name: "tblCustomerPayment");

            migrationBuilder.DropTable(
                name: "tblPayroll");

            migrationBuilder.DropTable(
                name: "tblSupplierInvoiceDetail");

            migrationBuilder.DropTable(
                name: "tblSupplierPayment");

            migrationBuilder.DropTable(
                name: "tblTransaction");

            migrationBuilder.DropTable(
                name: "tblCustomerInvoice");

            migrationBuilder.DropTable(
                name: "tblEmployee");

            migrationBuilder.DropTable(
                name: "tblStock");

            migrationBuilder.DropTable(
                name: "tblSupplierInvoice");

            migrationBuilder.DropTable(
                name: "tblFinancialYear");

            migrationBuilder.DropTable(
                name: "tblAccountSubControl");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblSupplier");

            migrationBuilder.DropTable(
                name: "tblAccountControl");

            migrationBuilder.DropTable(
                name: "tblAccountHead");

            migrationBuilder.DropTable(
                name: "tblBranch");

            migrationBuilder.DropTable(
                name: "tblCompany");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblBranchType");

            migrationBuilder.DropTable(
                name: "tblUserType");
        }
    }
}

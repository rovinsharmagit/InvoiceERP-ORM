using System;
using System.Collections.Generic;
using InvoiceERP.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceERP.iDbContext;

public class IDataContext : DbContext
{
   
    public IDataContext(DbContextOptions<IDataContext> options)
        : base(options)
    {
    }

    public  DbSet<TblAccountControl> TblAccountControls { get; set; }

    public  DbSet<TblAccountHead> TblAccountHeads { get; set; }

    public DbSet<TblAccountSubControl> TblAccountSubControls { get; set; }

    public DbSet<TblBranch> TblBranches { get; set; }

    public DbSet<TblBranchType> TblBranchTypes { get; set; }

    public DbSet<TblCategory> TblCategories { get; set; }

    public DbSet<TblCompany> TblCompanies { get; set; }

    public DbSet<TblCustomer> TblCustomers { get; set; }

    public DbSet<TblCustomerInvoice> TblCustomerInvoices { get; set; }

    public DbSet<TblCustomerInvoiceDetail> TblCustomerInvoiceDetails { get; set; }

    public DbSet<TblCustomerPayment> TblCustomerPayments { get; set; }

    public DbSet<TblEmployee> TblEmployees { get; set; }

    public DbSet<TblFinancialYear> TblFinancialYears { get; set; }

    public DbSet<TblPayroll> TblPayrolls { get; set; }

    public DbSet<TblStock> TblStocks { get; set; }

    public DbSet<TblSupplier> TblSuppliers { get; set; }

    public DbSet<TblSupplierInvoice> TblSupplierInvoices { get; set; }

    public DbSet<TblSupplierInvoiceDetail> TblSupplierInvoiceDetails { get; set; }

    public DbSet<TblSupplierPayment> TblSupplierPayments { get; set; }

    public DbSet<TblTransaction> TblTransactions { get; set; }

    public DbSet<TblUser> TblUsers { get; set; }

    public DbSet<TblUserType> TblUserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccountControl>(entity =>
        {
            entity.HasKey(e => e.AccountControlId);

            entity.ToTable("tblAccountControl");

            entity.Property(e => e.AccountControlId).HasColumnName("AccountControlID");
            entity.Property(e => e.AccountControlName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountHeadId).HasColumnName("AccountHeadID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblAccountControls)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAccountControl_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblAccountControls)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAccountControl_tblCompany");

            entity.HasOne(d => d.User).WithMany(p => p.TblAccountControls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAccountControl_tblUser");
        });

        modelBuilder.Entity<TblAccountHead>(entity =>
        {
            entity.HasKey(e => e.AccountHeadId);

            entity.ToTable("tblAccountHead");

            entity.Property(e => e.AccountHeadId).HasColumnName("AccountHeadID");
            entity.Property(e => e.AccountHeadName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TblAccountHeads)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAccountHead_tblUser");
        });

        modelBuilder.Entity<TblAccountSubControl>(entity =>
        {
            entity.HasKey(e => e.AccountSubControlId);

            entity.ToTable("tblAccountSubControl");

            entity.Property(e => e.AccountSubControlId).HasColumnName("AccountSubControlID");
            entity.Property(e => e.AccountControlId).HasColumnName("AccountControlID");
            entity.Property(e => e.AccountHeadId).HasColumnName("AccountHeadID");
            entity.Property(e => e.AccountSubControlName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AccountControl).WithMany(p => p.TblAccountSubControls)
                .HasForeignKey(d => d.AccountControlId)
                .HasConstraintName("FK_tblAccountSubControl_tblAccountControl");

            entity.HasOne(d => d.AccountHead).WithMany(p => p.TblAccountSubControls)
                .HasForeignKey(d => d.AccountHeadId)
                .HasConstraintName("FK_tblAccountSubControl_tblAccountHead");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblAccountSubControls)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAccountSubControl_tblBranch");

            entity.HasOne(d => d.User).WithMany(p => p.TblAccountSubControls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAccountSubControl_tblUser");
        });

        modelBuilder.Entity<TblBranch>(entity =>
        {
            entity.HasKey(e => e.BranchId);

            entity.ToTable("tblBranch");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.BranchAddress).HasMaxLength(300);
            entity.Property(e => e.BranchContact).HasMaxLength(50);
            entity.Property(e => e.BranchName).HasMaxLength(50);
            entity.Property(e => e.BranchTypeId).HasColumnName("BranchTypeID");
            entity.Property(e => e.BrchId).HasColumnName("BrchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

            entity.HasOne(d => d.BranchType).WithMany(p => p.TblBranches)
                .HasForeignKey(d => d.BranchTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBranch_tblBranchType");
        });

        modelBuilder.Entity<TblBranchType>(entity =>
        {
            entity.HasKey(e => e.BranchTypeId);

            entity.ToTable("tblBranchType");

            entity.Property(e => e.BranchTypeId).HasColumnName("BranchTypeID");
            entity.Property(e => e.BranchType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("tblCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoryName");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblCategories)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCategory_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblCategories)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCategory_tblCompany");

            entity.HasOne(d => d.User).WithMany(p => p.TblCategories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCategory_tblUser");
        });

        modelBuilder.Entity<TblCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.ToTable("tblCompany");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CompanyName).HasMaxLength(150);
            entity.Property(e => e.Logo).HasMaxLength(200);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("tblCustomer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CustomerArea)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Customername)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomer_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomer_tblCompany");

            entity.HasOne(d => d.User).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomer_tblUser");
        });

        modelBuilder.Entity<TblCustomerInvoice>(entity =>
        {
            entity.HasKey(e => e.CustomerInvoiceId);

            entity.ToTable("tblCustomerInvoice");

            entity.Property(e => e.CustomerInvoiceId).HasColumnName("CustomerInvoiceID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceDate).HasColumnType("date");
            entity.Property(e => e.InvoiceNo).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblCustomerInvoices)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomerInvoice_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblCustomerInvoices)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomerInvoice_tblCompany");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblCustomerInvoices)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tblCustomerInvoice_tblCustomer");

            entity.HasOne(d => d.User).WithMany(p => p.TblCustomerInvoices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomerInvoice_tblUser");
        });

        modelBuilder.Entity<TblCustomerInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerInvoiceDetailId);

            entity.ToTable("tblCustomerInvoiceDetail");

            entity.Property(e => e.CustomerInvoiceDetailId).HasColumnName("CustomerInvoiceDetailID");
            entity.Property(e => e.CustomerInvoiceId).HasColumnName("CustomerInvoiceID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.CustomerInvoice).WithMany(p => p.TblCustomerInvoiceDetails)
                .HasForeignKey(d => d.CustomerInvoiceId)
                .HasConstraintName("FK_tblCustomerInvoiceDetail_tblCustomerInvoice");

            entity.HasOne(d => d.Product).WithMany(p => p.TblCustomerInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblCustomerInvoiceDetail_tblStock");
        });

        modelBuilder.Entity<TblCustomerPayment>(entity =>
        {
            entity.HasKey(e => e.CustomerPaymentId);

            entity.ToTable("tblCustomerPayment");

            entity.Property(e => e.CustomerPaymentId).HasColumnName("CustomerPaymentID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerInvoiceId).HasColumnName("CustomerInvoiceID");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(150)
                .HasColumnName("invoiceNo");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblCustomerPayments)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomerPayment_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblCustomerPayments)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomerPayment_tblCompany");

            entity.HasOne(d => d.CustomerInvoice).WithMany(p => p.TblCustomerPayments)
                .HasForeignKey(d => d.CustomerInvoiceId)
                .HasConstraintName("FK_tblCustomerPayment_tblCustomerInvoice");

            entity.HasOne(d => d.User).WithMany(p => p.TblCustomerPayments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCustomerPayment_tblUser");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("tblEmployee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Cnic)
                .HasMaxLength(50)
                .HasColumnName("CNIC");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.ContactNo).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Photo).HasMaxLength(150);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmployee_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmployee_tblCompany");
        });

        modelBuilder.Entity<TblFinancialYear>(entity =>
        {
            entity.HasKey(e => e.FinancialYearId);

            entity.ToTable("tblFinancialYear");

            entity.Property(e => e.FinancialYearId).HasColumnName("FinancialYearID");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.FinancialYear).HasMaxLength(150);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TblFinancialYears)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblFinancialYear_tblUser");
        });

        modelBuilder.Entity<TblPayroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId);

            entity.ToTable("tblPayroll");

            entity.Property(e => e.PayrollId).HasColumnName("PayrollID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.PayrollInvoiceNo).HasMaxLength(150);
            entity.Property(e => e.SalaryMonth).HasMaxLength(50);
            entity.Property(e => e.SalaryYear).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblPayrolls)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_tblPayroll_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblPayrolls)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPayroll_tblCompany");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblPayrolls)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_tblPayroll_tblEmployee");

            entity.HasOne(d => d.User).WithMany(p => p.TblPayrolls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPayroll_tblUser");
        });

        modelBuilder.Entity<TblStock>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("tblStock");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.Manufacture).HasColumnType("date");
            entity.Property(e => e.ProductName).HasMaxLength(80);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblStocks)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStock_tblBranch");

            entity.HasOne(d => d.Category).WithMany(p => p.TblStocks)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_tblStock_tblCategory");

            entity.HasOne(d => d.Company).WithMany(p => p.TblStocks)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStock_tblCompany");

            entity.HasOne(d => d.User).WithMany(p => p.TblStocks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblStock_tblUser");
        });

        modelBuilder.Entity<TblSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId);

            entity.ToTable("tblSupplier");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.SupplierAddress).HasMaxLength(150);
            entity.Property(e => e.SupplierConatctNo).HasMaxLength(20);
            entity.Property(e => e.SupplierEmail).HasMaxLength(150);
            entity.Property(e => e.SupplierName).HasMaxLength(150);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblSuppliers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSupplier_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblSuppliers)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSupplier_tblCompany");

            entity.HasOne(d => d.User).WithMany(p => p.TblSuppliers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSupplier_tblUser");
        });

        modelBuilder.Entity<TblSupplierInvoice>(entity =>
        {
            entity.HasKey(e => e.SupplierInvoiceId).HasName("PK_tblSupplierInvoiceTable");

            entity.ToTable("tblSupplierInvoice");

            entity.Property(e => e.SupplierInvoiceId).HasColumnName("SupplierInvoiceID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.InvoiceDate).HasColumnType("date");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Branch).WithMany(p => p.TblSupplierInvoices)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSupplierInvoiceTable_tblBranch");

            entity.HasOne(d => d.Company).WithMany(p => p.TblSupplierInvoices)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSupplierInvoiceTable_tblCompany");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TblSupplierInvoices)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_tblSupplierInvoiceTable_tblSupplier");

            entity.HasOne(d => d.User).WithMany(p => p.TblSupplierInvoices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSupplierInvoice_tblUser");
        });

        modelBuilder.Entity<TblSupplierInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.SupplierInvoiceDetailId).HasName("PK_tblSupplierInvoiceDetailTable");

            entity.ToTable("tblSupplierInvoiceDetail");

            entity.Property(e => e.SupplierInvoiceDetailId).HasColumnName("SupplierInvoiceDetailID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PurchaseUnitPrice).HasColumnName("purchaseUnitPrice");
            entity.Property(e => e.SupplierInvoiceId).HasColumnName("SupplierInvoiceID");

            entity.HasOne(d => d.Product).WithMany(p => p.TblSupplierInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblSupplierInvoiceDetail_tblStock");

            entity.HasOne(d => d.SupplierInvoice).WithMany(p => p.TblSupplierInvoiceDetails)
                .HasForeignKey(d => d.SupplierInvoiceId)
                .HasConstraintName("FK_tblSupplierInvoiceDetail_tblSupplierInvoice");
        });

        modelBuilder.Entity<TblSupplierPayment>(entity =>
        {
            entity.HasKey(e => e.SupplierPaymentId);

            entity.ToTable("tblSupplierPayment");

            entity.Property(e => e.SupplierPaymentId).HasColumnName("SupplierPaymentID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(150)
                .HasColumnName("invoiceNo");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.SupplierInvoiceId).HasColumnName("SupplierInvoiceID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TblSupplierPayments)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_tblSupplierPayment_tblSupplier");

            entity.HasOne(d => d.User).WithMany(p => p.TblSupplierPayments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblSupplierPayment_tblUser");
        });

        modelBuilder.Entity<TblTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_TransectionTable");

            entity.ToTable("tblTransaction");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.AccountControlId).HasColumnName("AccountControlID");
            entity.Property(e => e.AccountHeadId).HasColumnName("AccountHeadID");
            entity.Property(e => e.AccountSubControlId).HasColumnName("AccountSubControlID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.FinancialYearId).HasColumnName("FinancialYearID");
            entity.Property(e => e.InvoiceNo).HasMaxLength(150);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionTitle).HasMaxLength(150);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AccountControl).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.AccountControlId)
                .HasConstraintName("FK_tblTransaction_tblAccountControl");

            entity.HasOne(d => d.AccountHead).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.AccountHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblTransaction_tblAccountHead");

            entity.HasOne(d => d.AccountSubControl).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.AccountSubControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblTransection_tblAccountSubControl");

            entity.HasOne(d => d.FinancialYear).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.FinancialYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblTransaction_tblFinancialYear");

            entity.HasOne(d => d.User).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblTransaction_tblUser");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tblUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ContactNo).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.UserName).HasMaxLength(150);
            entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

            entity.HasOne(d => d.UserType).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblUser_tblUserType");
        });

        modelBuilder.Entity<TblUserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId);

            entity.ToTable("tblUserType");

            entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");
            entity.Property(e => e.UserType).HasMaxLength(150);
        });

    }
}

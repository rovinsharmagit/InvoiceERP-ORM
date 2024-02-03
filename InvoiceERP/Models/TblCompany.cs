using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblCompany
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Logo { get; set; }

    public  ICollection<TblAccountControl> TblAccountControls { get; } = new List<TblAccountControl>();

    public  ICollection<TblCategory> TblCategories { get; } = new List<TblCategory>();

    public  ICollection<TblCustomerInvoice> TblCustomerInvoices { get; } = new List<TblCustomerInvoice>();

    public  ICollection<TblCustomerPayment> TblCustomerPayments { get; } = new List<TblCustomerPayment>();

    public  ICollection<TblCustomer> TblCustomers { get; } = new List<TblCustomer>();

    public  ICollection<TblEmployee> TblEmployees { get; } = new List<TblEmployee>();

    public  ICollection<TblPayroll> TblPayrolls { get; } = new List<TblPayroll>();

    public  ICollection<TblStock> TblStocks { get; } = new List<TblStock>();

    public  ICollection<TblSupplierInvoice> TblSupplierInvoices { get; } = new List<TblSupplierInvoice>();

    public  ICollection<TblSupplier> TblSuppliers { get; } = new List<TblSupplier>();
}

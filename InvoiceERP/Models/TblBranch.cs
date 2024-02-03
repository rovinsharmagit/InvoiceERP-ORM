using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public class TblBranch
{
    public int BranchId { get; set; }

    public int BranchTypeId { get; set; }

    public string BranchName { get; set; } = null!;

    public string BranchContact { get; set; } = null!;

    public string BranchAddress { get; set; } = null!;

    public int CompanyId { get; set; }

    public int? BrchId { get; set; }

    public TblBranchType BranchType { get; set; } = null!;

    public ICollection<TblAccountControl> TblAccountControls { get; } = new List<TblAccountControl>();

    public ICollection<TblAccountSubControl> TblAccountSubControls { get; } = new List<TblAccountSubControl>();

    public ICollection<TblCategory> TblCategories { get; } = new List<TblCategory>();

    public ICollection<TblCustomerInvoice> TblCustomerInvoices { get; } = new List<TblCustomerInvoice>();

    public ICollection<TblCustomerPayment> TblCustomerPayments { get; } = new List<TblCustomerPayment>();

    public ICollection<TblCustomer> TblCustomers { get; } = new List<TblCustomer>();

    public ICollection<TblEmployee> TblEmployees { get; } = new List<TblEmployee>();

    public ICollection<TblPayroll> TblPayrolls { get; } = new List<TblPayroll>();

    public ICollection<TblStock> TblStocks { get; } = new List<TblStock>();

    public ICollection<TblSupplierInvoice> TblSupplierInvoices { get; } = new List<TblSupplierInvoice>();

    public ICollection<TblSupplier> TblSuppliers { get; } = new List<TblSupplier>();
}

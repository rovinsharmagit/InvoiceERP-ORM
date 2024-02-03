using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblCustomer
{
    public int CustomerId { get; set; }

    public string Customername { get; set; } = null!;

    public int CustomerContact { get; set; }

    public string CustomerArea { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int BranchId { get; set; }

    public int CompanyId { get; set; }

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  ICollection<TblCustomerInvoice> TblCustomerInvoices { get; } = new List<TblCustomerInvoice>();

    public  TblUser User { get; set; } = null!;
}

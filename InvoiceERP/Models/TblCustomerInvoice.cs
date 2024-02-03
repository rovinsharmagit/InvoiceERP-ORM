using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblCustomerInvoice
{
    public int CustomerInvoiceId { get; set; }

    public int CustomerId { get; set; }

    public int CompanyId { get; set; }

    public int BranchId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public string Title { get; set; } = null!;

    public double TotalAmount { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string? Description { get; set; }

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  TblCustomer Customer { get; set; } = null!;

    public  ICollection<TblCustomerInvoiceDetail> TblCustomerInvoiceDetails { get; } = new List<TblCustomerInvoiceDetail>();

    public  ICollection<TblCustomerPayment> TblCustomerPayments { get; } = new List<TblCustomerPayment>();

    public  TblUser User { get; set; } = null!;
}

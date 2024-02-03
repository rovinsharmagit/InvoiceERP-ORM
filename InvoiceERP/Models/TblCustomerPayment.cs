using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblCustomerPayment
{
    public int CustomerPaymentId { get; set; }

    public int CustomerId { get; set; }

    public int CustomerInvoiceId { get; set; }

    public int BranchId { get; set; }

    public int CompanyId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public double TotalAmount { get; set; }

    public double PaidAmount { get; set; }

    public double RemainingBalance { get; set; }

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  TblCustomerInvoice CustomerInvoice { get; set; } = null!;

    public  TblUser User { get; set; } = null!;
}

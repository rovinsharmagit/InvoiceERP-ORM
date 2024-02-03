using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblTransaction
{
    public int TransactionId { get; set; }

    public int FinancialYearId { get; set; }

    public int AccountHeadId { get; set; }

    public int AccountControlId { get; set; }

    public int AccountSubControlId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public int CompanyId { get; set; }

    public int BranchId { get; set; }

    public double Credit { get; set; }

    public double Debit { get; set; }

    public System.DateTime TransactionDate { get; set; }

    public string TransactionTitle { get; set; } = null!;

    public int UserId { get; set; }

    public  TblAccountControl AccountControl { get; set; } = null!;

    public  TblAccountHead AccountHead { get; set; } = null!;

    public  TblAccountSubControl AccountSubControl { get; set; } = null!;

    public  TblFinancialYear FinancialYear { get; set; } = null!;

    public  TblUser User { get; set; } = null!;
}

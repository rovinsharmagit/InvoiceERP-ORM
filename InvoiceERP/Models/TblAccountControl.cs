using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblAccountControl
{
    public int AccountControlId { get; set; }

    public int CompanyId { get; set; }

    public int BranchId { get; set; }

    public int AccountHeadId { get; set; }

    public string AccountControlName { get; set; } = null!;

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  ICollection<TblAccountSubControl> TblAccountSubControls { get; } = new List<TblAccountSubControl>();

    public  ICollection<TblTransaction> TblTransactions { get; } = new List<TblTransaction>();

    public  TblUser User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public class TblAccountSubControl
{
    public int AccountSubControlId { get; set; }

    public int AccountHeadId { get; set; }

    public int AccountControlId { get; set; }

    public int CompanyId { get; set; }

    public int BranchId { get; set; }

    public string AccountSubControlName { get; set; } = null!;

    public int UserId { get; set; }

    public TblAccountControl AccountControl { get; set; } = null!;

    public TblAccountHead AccountHead { get; set; } = null!;

    public TblBranch Branch { get; set; } = null!;

    public ICollection<TblTransaction> TblTransactions { get; } = new List<TblTransaction>();

    public TblUser User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public class TblAccountHead
{
    public int AccountHeadId { get; set; }

    public int CompanyId { get; set; }

    public int BranchId { get; set; }

    public string AccountHeadName { get; set; } = null!;

    public int Code { get; set; }

    public int UserId { get; set; }

    public  ICollection<TblAccountSubControl> TblAccountSubControls { get; } = new List<TblAccountSubControl>();

    public  ICollection<TblTransaction> TblTransactions { get; } = new List<TblTransaction>();

    public  TblUser User { get; set; } = null!;
}

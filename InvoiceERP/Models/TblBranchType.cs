using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblBranchType
{
    public int BranchTypeId { get; set; }

    public string BranchType { get; set; } = null!;

    public ICollection<TblBranch> TblBranches { get; } = new List<TblBranch>();
}

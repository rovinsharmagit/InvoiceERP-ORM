using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public int BranchId { get; set; }

    public int CompanyId { get; set; }

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public TblCompany Company { get; set; } = null!;

    public ICollection<TblStock> TblStocks { get; } = new List<TblStock>();

    public TblUser User { get; set; } = null!;
}

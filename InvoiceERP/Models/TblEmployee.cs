using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblEmployee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public string? Photo { get; set; }

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Cnic { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double MonthlySalary { get; set; }

    public int BranchId { get; set; }

    public int CompanyId { get; set; }

    public int UserId { get; set; }

     public  TblUser User { get; set; } = null!;

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  ICollection<TblPayroll> TblPayrolls { get; } = new List<TblPayroll>();
}

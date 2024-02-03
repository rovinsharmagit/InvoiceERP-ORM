using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblPayroll
{
    public int PayrollId { get; set; }
    
    [Required(ErrorMessage = "Employee Name is Required")]
    [Display(Name = "Select Employee")]
    public int EmployeeId { get; set; }

    public int BranchId { get; set; }

    public int CompanyId { get; set; }
    
    [Required(ErrorMessage = "Transfer Amount is Required")]
    [Display(Name = "Transfer Amount")]
    public double TransferAmount { get; set; }

    public string PayrollInvoiceNo { get; set; } = null!;

    public System.DateTime PaymentDate { get; set; }
    
    [Required(ErrorMessage = "Salary Month is Required")]
    [Display(Name = "Salary Of Month")]
    public string SalaryMonth { get; set; } = null!;

    public System.DateTime SalaryYear { get; set; } 

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  TblEmployee Employee { get; set; } = null!;

    public  TblUser User { get; set; } = null!;
}

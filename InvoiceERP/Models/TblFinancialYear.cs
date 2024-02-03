using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblFinancialYear
{
    public int FinancialYearId { get; set; }

    public int UserId { get; set; }
    
    [Required(ErrorMessage = "Financial Year is Required")]
    [DataType(DataType.Date)]
    [Display(Name = "Select Financial Year Start Date")]
    public string FinancialYear { get; set; } =null!;
    
    [Required(ErrorMessage = "Status is Required")]
    [Display(Name = "Status")]
    public bool IsActive { get; set; }

    public DateTime StartDate { get; set; }

     public DateTime EndDate { get; set; }

    public  ICollection<TblTransaction> TblTransactions { get; } = new List<TblTransaction>();

    public  TblUser User { get; set; } = null!;
}

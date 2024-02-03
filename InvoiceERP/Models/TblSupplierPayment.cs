using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblSupplierPayment
{
    public int SupplierPaymentId { get; set; }
    
    [Required(ErrorMessage = "Supplier Required!")]
    [Display(Name = "Select Supplier")]
    public int SupplierId { get; set; }
    
    [Required(ErrorMessage = "Invoice No. Required!")]
    [Display(Name = "Enter Invoice No.")]
    public int SupplierInvoiceId { get; set; }
    
    public int CompanyId { get; set; }

    public int BranchId { get; set; }
    
    public string InvoiceNo { get; set; } = null!;
    [Required(ErrorMessage = "Total Amount Required!")]
    [Display(Name = "Total Amount")]
    [DataType(DataType.Currency)]
    public double TotalAmount { get; set; }
    
    [Required(ErrorMessage = "Payment Amount Required!")]
    [Display(Name = "Payment Amount")]
    [DataType(DataType.Currency)]
    public double PaymentAmount { get; set; }

    public double RemainingBalance { get; set; }

    public int UserId { get; set; }

    public  TblSupplier Supplier { get; set; } = null!;

    public  TblUser User { get; set; } = null!;
}

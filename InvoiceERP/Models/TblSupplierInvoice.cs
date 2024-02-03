using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblSupplierInvoice
{
    public int SupplierInvoiceId { get; set; }
    
    [Required(ErrorMessage = "Supplier Required!")]
    [Display(Name = "Select Supplier")]
    public int SupplierId { get; set; }
    
    public int CompanyId { get; set; }

    public int BranchId { get; set; }

    public int InvoiceNo { get; set; }
    
    [Required(ErrorMessage = "Total Amount Required!")]
    [Display(Name = "Total Amount")]
    [DataType(DataType.Currency)]
    public double TotalAmount { get; set; }

    public System.DateTime InvoiceDate { get; set; }

    public string Description { get; set; } = null!;

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  TblSupplier Supplier { get; set; } = null!;

    public  ICollection<TblSupplierInvoiceDetail> TblSupplierInvoiceDetails { get; } = new List<TblSupplierInvoiceDetail>();

    public  TblUser User { get; set; } = null!;
}

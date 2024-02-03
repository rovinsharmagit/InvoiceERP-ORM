using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblStock
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public int CompanyId { get; set; }

    public int BranchId { get; set; }
    
    [Required(ErrorMessage = "Product Name is Required!")]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; } = null!;
    
    [Required(ErrorMessage = "Quantity is Required!")]
    [Display(Name = "Quantity")]
    public double Quantity { get; set; }
    
    [Required(ErrorMessage = "Sale Unit Price is Required!")]
    [Display(Name = "Sale Unit Price")]
    public double SaleUnitPrice { get; set; }
    
    [Required(ErrorMessage = "Current Purchase Unit Price is Required!")]
    [Display(Name = "Current Purchase Unit Price")]
    public double CurrentPurchaseUnitPrice { get; set; }
    
    [Required(ErrorMessage = "Expiry Date is Required!")]
    [Display(Name = "Expiry Date")]
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }
    
    [Required(ErrorMessage = "Manufacture Date is Required!")]
    [Display(Name = "Manufacture Date")]
    [DataType(DataType.Date)]
    public DateTime Manufacture { get; set; }
    
    [Required(ErrorMessage = "StockTreshHoldQuantity is Required!")]
    [Display(Name = "StockTreshHoldQuantity")]
    public int StockTreshHoldQuantity { get; set; }

    public string? Description { get; set; }

    public int UserId { get; set; }

    public bool IsActive { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCategory Category { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  ICollection<TblCustomerInvoiceDetail> TblCustomerInvoiceDetails { get; } = new List<TblCustomerInvoiceDetail>();

    public  ICollection<TblSupplierInvoiceDetail> TblSupplierInvoiceDetails { get; } = new List<TblSupplierInvoiceDetail>();

    public  TblUser User { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblSupplier
{
    public int SupplierId { get; set; }

    [Required(ErrorMessage = "Supplier Name Required!")]
    [Display(Name = "Supplier Name")]
    public string SupplierName { get; set; } = null!;
    
    [Required(ErrorMessage = "Contact No. is Required!")]
    [Display(Name = "Supplier Contact No.")]
    [DataType(DataType.PhoneNumber)]
    public string SupplierConatctNo { get; set; } = null!;
    
    [Required(ErrorMessage = "Address is Required!")]
    [Display(Name = "Supplier Address")]
    public string? SupplierAddress { get; set; }
    
    [Required(ErrorMessage = "Email is Required!")]
    [Display(Name = "Supplier Email Address")]
    [DataType(DataType.EmailAddress)]
    public string? SupplierEmail { get; set; }

    public string? Description { get; set; }

    public int BranchId { get; set; }

    public int CompanyId { get; set; }

    public int UserId { get; set; }

    public  TblBranch Branch { get; set; } = null!;

    public  TblCompany Company { get; set; } = null!;

    public  ICollection<TblSupplierInvoice> TblSupplierInvoices { get; } = new List<TblSupplierInvoice>();

    public  ICollection<TblSupplierPayment> TblSupplierPayments { get; } = new List<TblSupplierPayment>();

    public  TblUser User { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblUser
{
    public int UserId { get; set; }
    
    [Required(ErrorMessage = " User Type Required!")]
    [Display(Name = "Please Select User Type")]
    public int UserTypeId { get; set; }
    
    [Required(ErrorMessage = "FullName Required!")]
    [Display(Name = "Enter Full Name")]
    public string FullName { get; set; } = null!;
    
    [Required(ErrorMessage = "Email Required!")]
    [Display(Name = "Enter Valid Email Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Contact No. Required!")]
    [Display(Name = "Enter Valid Contact No.")]
    [DataType(DataType.PhoneNumber)]
    public string ContactNo { get; set; } = null!;
    
    [Required(ErrorMessage = "UserName Required!")]
    [Display(Name = "Enter UserName")]
    public string UserName { get; set; } = null!;
    
    [Required(ErrorMessage = "Password Required!")]
    [Display(Name = "Enter Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Display(Name = "Status")]
    public bool IsActive { get; set; }

    public  ICollection<TblAccountControl> TblAccountControls { get; } = new List<TblAccountControl>();

    public  ICollection<TblAccountHead> TblAccountHeads { get; } = new List<TblAccountHead>();

    public  ICollection<TblAccountSubControl> TblAccountSubControls { get; } = new List<TblAccountSubControl>();

    public  ICollection<TblCategory> TblCategories { get; } = new List<TblCategory>();

    public  ICollection<TblCustomerInvoice> TblCustomerInvoices { get; } = new List<TblCustomerInvoice>();

    public  ICollection<TblCustomerPayment> TblCustomerPayments { get; } = new List<TblCustomerPayment>();

    public  ICollection<TblCustomer> TblCustomers { get; } = new List<TblCustomer>();

    public  ICollection<TblFinancialYear> TblFinancialYears { get; } = new List<TblFinancialYear>();

    public  ICollection<TblPayroll> TblPayrolls { get; } = new List<TblPayroll>();

    public  ICollection<TblStock> TblStocks { get; } = new List<TblStock>();

    public  ICollection<TblSupplierInvoice> TblSupplierInvoices { get; } = new List<TblSupplierInvoice>();

    public  ICollection<TblSupplierPayment> TblSupplierPayments { get; } = new List<TblSupplierPayment>();

    public  ICollection<TblSupplier> TblSuppliers { get; } = new List<TblSupplier>();

    public  ICollection<TblTransaction> TblTransactions { get; } = new List<TblTransaction>();

    public  TblUserType? UserType { get; set; } 
}

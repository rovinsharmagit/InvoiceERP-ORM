using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceERP.Models;

public  class TblUserType
{
    
    public int UserTypeId { get; set; }

    [Required(ErrorMessage = "User Type Is Required!")]
    [Display(Name = "User Type")]
    public string UserType { get; set; } = null!;

    public  ICollection<TblUser> TblUsers { get; } = new List<TblUser>();
}

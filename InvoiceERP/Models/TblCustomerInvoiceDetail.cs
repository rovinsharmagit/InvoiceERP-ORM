using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblCustomerInvoiceDetail
{
    public int CustomerInvoiceDetailId { get; set; }

    public int CustomerInvoiceId { get; set; }

    public int ProductId { get; set; }

    public double SaleQuantity { get; set; }

    public double SaleUnitPrice { get; set; }

    public  TblCustomerInvoice CustomerInvoice { get; set; } = null!;

    public  TblStock Product { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace InvoiceERP.Models;

public  class TblSupplierInvoiceDetail
{
    public int SupplierInvoiceDetailId { get; set; }

    public int SupplierInvoiceId { get; set; }

    public int ProductId { get; set; }

    public int PurchaseQuantity { get; set; }

    public double PurchaseUnitPrice { get; set; }

    public  TblStock Product { get; set; } = null!;

    public  TblSupplierInvoice SupplierInvoice { get; set; } = null!;
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPT.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoices
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public string Title { get; set; }
        public int CustomerID { get; set; }
        public string Address { get; set; }
        public Nullable<int> InvoiceStatusID { get; set; }
        public int InvoiceTypeID { get; set; }
        public Nullable<int> PaymentTypeID { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public int UserID { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual InvoiceStatuses InvoiceStatuses { get; set; }
        public virtual InvoiceTypes InvoiceTypes { get; set; }
        public virtual PaymentTypes PaymentTypes { get; set; }
        public virtual Users Users { get; set; }
    }
}

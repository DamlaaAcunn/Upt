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
    
    public partial class Deposit
    {
        public int DepositID { get; set; }
        public int CustomerID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool IsPayment { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
    
        public virtual Customers Customers { get; set; }
    }
}

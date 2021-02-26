using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPT.Entities
{
    public class UserViewModel
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int InvoicesId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CustomerType { get; set; }
        public int PaymentType { get; set; }
        public string IdentityNo { get; set; }
        public int CustomerStatus { get; set; }
        public int InvoiceType { get; set; }
        public string TaxNumber { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceTitle{ get; set; }
        public string InvoiceDescription { get; set; }
        public int Unit { get; set; }
        public decimal? Price { get; set; }
        public decimal VatRatio { get; set; }
        public decimal? Deposit { get; set; }
        public string IsDepositPayment { get; set; }
        public DateTime Register { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public List<int> InvoicesIdList { get; set; }
        public List<Invoice> Invoices { get; set; }

    }
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceTitle { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}

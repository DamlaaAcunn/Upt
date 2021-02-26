using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;

namespace UPT.Services
{
    public class DepositService : IDepositService
    {
        public UserViewModel DepositPayment(int CustomerId)
        {
            UserViewModel userViewModel = new UserViewModel();
            List<Invoice> invoicesList = new List<Invoice>();
            using (UPTEntities dbContext = new UPTEntities())
            {
                // Ödenmemiş borçları getir
                var invoices = dbContext.Invoices.Where(x => x.CustomerID == CustomerId && x.InvoiceStatusID != 1).ToList();
                if (invoices.Count > 0)
                {
                    foreach (var item in invoices)
                    {
                        Invoice invoice = new Invoice();
                        invoice.InvoiceNumber = item.InvoiceNumber;
                        invoice.InvoiceTitle = item.Title;
                        invoice.PaymentDate = item.PaymentDate;
                        invoicesList.Add(invoice);
                    }
                    userViewModel.Invoices = invoicesList;
                }
                else
                {
                    //Borç olmadığından depozito iade et

                    var deposit = dbContext.Deposit.Where(x => x.CustomerID == CustomerId).FirstOrDefault();
                    deposit.IsPayment = true;
                    deposit.PaidDate = DateTime.Now;
                    dbContext.SaveChanges();

                    // Abonelik kapatma 
                    var customer = dbContext.Customers.Where(x => x.CustomerID == CustomerId).FirstOrDefault();
                    customer.CustomerStatusID = 2;
                    dbContext.SaveChanges();
                }
            }
            return userViewModel;
        }
    }
}

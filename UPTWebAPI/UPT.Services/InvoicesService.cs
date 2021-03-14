using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;


namespace UPT.Services
{
    public class InvoicesService : IInvoicesService
    {
        public void CreateExtract()
        {
            //Her ay sonundan 2 gün önce ekstre kesilme işlemi
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-2);
            if (DateTime.Now >= date)
            {
                using (UPTEntities dbContext = new UPTEntities())
                {
                    //Ay sonunda Fatura tablosuna kayıt atar

                    //Aktif olan aboneleri çek 

                    var customer = dbContext.Customers.Where(x => x.CustomerStatusID == 1).ToList();

                    foreach (var item in customer)
                    {
                        var invoices = dbContext.Invoices.Where(x => x.CustomerID == item.CustomerID).FirstOrDefault();
                        //Sabit fiyat üzerinden olduğu için bu tablodaki son kayıtta bulunan fiyatı aldım.Tabloyu kullanabilmek adına yaptım bunu.
                        var newInvoices = InvoicesInsert(invoices);
                    }
                }
            }
        }
        public void InsertInvoices()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-2);
            if (DateTime.Now >= date)
            {
                using (UPTEntities dbContext = new UPTEntities())
                {
                    //Ay sonunda Fatura tablosuna kayıt atar

                    //Aktif olan aboneleri çek 

                    var customer = dbContext.Customers.Where(x => x.CustomerStatusID == 1).ToList();

                    foreach (var item in customer)
                    {
                        var invoices = dbContext.Invoices.Where(x => x.CustomerID == item.CustomerID).FirstOrDefault();
                        //Sabit fiyat üzerinden olduğu için bu tablodaki son kayıtta bulunan fiyatı aldım.Tabloyu kullanabilmek adına yaptım bunu.
                        var newInvoices = InvoicesInsert(invoices);
                    }
                }
            }
        }
        public List<UserViewModel> GetInvoices(UserViewModel userViewModel)
        {//ödenmemiş faturaları getirir
            List<UserViewModel> userList = new List<UserViewModel>();
            using (UPTEntities dbContext = new UPTEntities())
            {
                var customer = dbContext.Customers.Where(x => x.IdentityNumber == userViewModel.IdentityNo || x.TaxNumber == userViewModel.TaxNumber || x.UserID == userViewModel.UserId && x.CustomerStatusID == 1).FirstOrDefault();
                var invoices = dbContext.Invoices.Where(x => x.CustomerID == customer.CustomerID && x.InvoiceStatusID == 2).ToList();
                if (invoices.Count > 0)
                {
                    foreach (var item in invoices)
                    {
                        UserViewModel user = new UserViewModel();
                        user.CustomerId = customer.CustomerID;
                        user.InvoicesId = item.InvoiceID;
                        user.UserName = customer.Name;
                        user.Adress = customer.Address;
                        user.IdentityNo = customer.IdentityNumber;
                        user.Phone = customer.Phone;
                        user.TaxNumber = customer.TaxNumber;
                        user.Register = customer.Register;
                        user.Price = item.Price;
                        user.InvoiceNumber = item.InvoiceNumber;
                        user.InvoiceTitle = item.Title;
                        user.PaymentDate = item.PaymentDate;
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }
        public List<UserViewModel> GetExtract(UserViewModel userViewModel)
        {//Fatura ödeme servisi
            List<UserViewModel> userList = new List<UserViewModel>();
            using (UPTEntities dbContext = new UPTEntities())
            {
                var customer = dbContext.Customers.Where(x => x.IdentityNumber == userViewModel.IdentityNo || x.TaxNumber == userViewModel.TaxNumber || x.UserID == userViewModel.UserId).FirstOrDefault();
                var invoices = dbContext.Invoices.Where(x => x.CustomerID == customer.CustomerID && x.InvoiceStatusID == 1).ToList();
                if (invoices.Count > 0)
                {
                    foreach (var item in invoices)
                    {
                        UserViewModel user = new UserViewModel();
                        user.CustomerId = customer.CustomerID;
                        user.InvoicesId = item.InvoiceID;
                        user.UserName = customer.Name;
                        user.Adress = customer.Address;
                        user.IdentityNo = customer.IdentityNumber;
                        user.Phone = customer.Phone;
                        user.TaxNumber = customer.TaxNumber;
                        user.Register = customer.Register;
                        user.Price = item.Price;
                        user.InvoiceNumber = item.InvoiceNumber;
                        user.InvoiceTitle = item.Title;
                        user.PaidDate = item.PaidDate;
                        user.PaymentDate = item.PaymentDate;
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }
        public Invoices InvoicesInsert(Invoices invoices)
        {
            Invoices newInvoices = new Invoices();
            using (UPTEntities dbContext = new UPTEntities())
            {
                newInvoices.CustomerID = invoices.CustomerID;
                newInvoices.UserID = invoices.UserID;
                newInvoices.Title = invoices.Title;
                newInvoices.InvoiceNumber = invoices.InvoiceNumber;
                newInvoices.InvoiceTypeID = invoices.InvoiceTypeID;
                newInvoices.Address = invoices.Address;
                newInvoices.CreateDateTime = DateTime.Now;
                newInvoices.Price = invoices.Price;
                newInvoices.PaymentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
                dbContext.Invoices.Add(invoices);
                dbContext.SaveChanges();
            }
            return invoices;
        }

    }
}

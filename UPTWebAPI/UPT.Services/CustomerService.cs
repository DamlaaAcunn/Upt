using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;

namespace UPT.Services
{
    public class CustomerService : ICustomerService
    {
        public void InsertCustomer(UserViewModel userViewModel)
        {
            using (UPTEntities dbContext = new UPTEntities())
            {
                if (userViewModel != null)
                {
                    var user = UserInsert(userViewModel);
                    userViewModel.UserId = user.UserID;

                    var customer = CustomerInsert(userViewModel);
                    userViewModel.CustomerId = customer.CustomerID;
                    var invoices = InvoicesInsert(userViewModel);
                    userViewModel.InvoicesId = invoices.InvoiceID;
                    var deposit = DepositInsert(userViewModel);                  
                }
            }
        }
        public List<UserViewModel> GetCustomer()
        {

            var users = new List<UserViewModel>();
            using (UPTEntities dbContext = new UPTEntities())
            {
                var customers = dbContext.Customers.Where(x => x.Users.RoleID == 2).ToList();               
                if (customers != null)
                {
                    foreach (var item in customers)
                    {
                        var deposit = dbContext.Deposit.Where(x => x.CustomerID == item.CustomerID).FirstOrDefault();
                        
                        var user = new UserViewModel();
                        user.CustomerId = item.CustomerID;
                        user.UserName = item.Name;
                        user.Adress = item.Address;
                        user.IdentityNo = item.IdentityNumber;
                        user.Phone = item.Phone;
                        user.TaxNumber = item.TaxNumber;
                        user.Register = item.Register;
                        user.Deposit = deposit.Price;
                        if (deposit.IsPayment)
                            user.IsDepositPayment = "İade Edildi";
                        else
                            user.IsDepositPayment = "İade Edilmedi";
                                  
                        users.Add(user);
                    }


                }

            }
            return users;
        }
        public Customers CustomerInsert(UserViewModel userViewModel)
        {
            Customers customers = new Customers();
            using (UPTEntities dbContext = new UPTEntities())
            {
                customers.Name = userViewModel.UserName;
                customers.UserID = userViewModel.UserId;
                customers.IdentityNumber = userViewModel.IdentityNo;
                customers.TaxNumber = userViewModel.TaxNumber;
                customers.CustomerStatusID = userViewModel.CustomerStatus;
                customers.CustomerTypeID = userViewModel.CustomerType;
                customers.Email = userViewModel.Email;
                customers.Phone = userViewModel.Phone;
                customers.Address = userViewModel.Adress;
                customers.Register = DateTime.Now;
                dbContext.Customers.Add(customers);
                dbContext.SaveChanges();
            }
            return customers;
        }
        public Users UserInsert(UserViewModel userViewModel)
        {
            Users users = new Users();
            using (UPTEntities dbContext = new UPTEntities())
            {
                users.Password = "1234";
                users.RoleID = 2;
                users.UserName = userViewModel.UserName;
                users.Register = DateTime.Now;
                dbContext.Users.Add(users);
                dbContext.SaveChanges();
            }
            return users;
        }
        public Invoices InvoicesInsert(UserViewModel userViewModel)
        {  //Yeni abone olduğunda içinde bulunduğu ay sonu için ödenecek ilk fatura kaydını oluşturur.
            Invoices invoices = new Invoices();
            using (UPTEntities dbContext = new UPTEntities())
            {
                invoices.CustomerID = userViewModel.CustomerId;
                invoices.UserID = userViewModel.UserId;
                invoices.Title = userViewModel.InvoiceTitle;
                invoices.InvoiceNumber = userViewModel.InvoiceNumber;
                invoices.InvoiceTypeID = userViewModel.InvoiceType;
                invoices.Address = userViewModel.Adress;
                invoices.CreateDateTime = DateTime.Now;
                invoices.InvoiceStatusID = 2;
                invoices.Price = userViewModel.Price;
                invoices.PaymentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
                dbContext.Invoices.Add(invoices);
                dbContext.SaveChanges();
            }
            return invoices;
        }
        public Deposit DepositInsert(UserViewModel userViewModel)
        {
            Deposit deposit = new Deposit();
            using (UPTEntities dbContext = new UPTEntities())
            {
                deposit.CustomerID = userViewModel.CustomerId;
                deposit.Price = userViewModel.Deposit;
                deposit.IsPayment = false; // Deposite 0 ise geri ödenmedi 1 ise ödendi
                dbContext.Deposit.Add(deposit);
                dbContext.SaveChanges();
            }
            return deposit;
        }
    }
}

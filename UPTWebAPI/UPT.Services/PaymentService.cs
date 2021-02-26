using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;


namespace UPT.Services
{
    public class PaymentService : IPaymentService
    {
        public void UpdatePayment(UserViewModel userViewModel)
        {
            if (userViewModel.InvoicesIdList.Count > 0)
            {
                using (UPTEntities dbContext = new UPTEntities())
                {
                    foreach (var item in userViewModel.InvoicesIdList)
                    {
                        var invoces = dbContext.Invoices.Where(x => x.InvoiceID == item).FirstOrDefault();
                        invoces.InvoiceStatusID = 1;
                        invoces.PaymentTypeID = userViewModel.PaymentType;
                        invoces.PaidDate = DateTime.Now;
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}

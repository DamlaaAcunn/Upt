using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;

namespace UPT.Services
{
    public interface IInvoicesService
    {
        void CreateExtract();
        void InsertInvoices();
        List<UserViewModel> GetInvoices(UserViewModel userViewModel);
        List<UserViewModel> GetExtract(UserViewModel userViewModel);
        Invoices InvoicesInsert(Invoices invoices);
    }
}

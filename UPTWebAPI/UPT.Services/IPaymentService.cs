using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;


namespace UPT.Services
{
    public interface IPaymentService
    {
        void UpdatePayment(UserViewModel userViewModel);
    }
}

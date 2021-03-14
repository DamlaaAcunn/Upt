using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using UPT.Entities;
using UPT.Helpers;
using UPT.Services;

namespace UPTWebAPI.Controllers
{
    public class DepositController : ApiController
    {
        // GET: Deposit
        private readonly IDepositService _IDepositService;
        public DepositController(IDepositService paymentService)
        {
            _IDepositService = paymentService;
        }

        [HttpPost]
        [JSONFilter(RootType = typeof(UserViewModel))]
        public JsonResult<CustomerResultResponse> DepositPayment([FromBody] UserViewModel userViewModel)
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {
                var deposit = _IDepositService.DepositPayment(userViewModel.CustomerId);
                if (deposit.Invoices == null)
                {
                    response.APIResponse.ResponseDescription = "Abonelik kapatma işlemi tamamlanmıştır.";
                }
                else
                {
                    
                    response.APIResponse.ResponseDescription = "Ödenmemiş Borç Bulunmaktadır.";
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
            return Json(response);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using UPT.Entities;
using UPT.Helpers;
using UPT.Services;

namespace UPTWebAPI.Controllers
{
    public class PaymentController : ApiController
    {
        // GET: Payment
        private readonly IPaymentService _IPaymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _IPaymentService = paymentService;
        }

        [HttpPost]
        [JSONFilter(RootType = typeof(UserViewModel))]
        public JsonResult<CustomerResultResponse> UpdatePayment([FromBody] UserViewModel userViewModel)
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {
                _IPaymentService.UpdatePayment(userViewModel);
                response.APIResponse.ResponseCode = "000";
            }
            catch (Exception excp)
            {
                Console.Write(excp.Message);
            }
            return Json(response);
        }
    }
}
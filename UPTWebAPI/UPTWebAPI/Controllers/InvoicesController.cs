using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using UPT.Entities;
using UPT.Helpers;
using UPT.Services;

namespace UPTWebAPI.Controllers
{
    public class InvoicesController : ApiController
    {
        private readonly IInvoicesService _IInvoicesService;
        public InvoicesController(IInvoicesService invoicesService)
        {
            _IInvoicesService = invoicesService;
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(InvoicesController))]
        public JsonResult<CustomerResultResponse> InsertInvoices()
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {
                _IInvoicesService.InsertInvoices();
                response.APIResponse.ResponseCode = "000";
            }
            catch (Exception exc)
            {

            }
            return Json(response);
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(UserViewModel))]
        public JsonResult<CustomerResultResponse> GetInvoices([FromBody] UserViewModel userViewModel)
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {
                List<UserViewModel> userList = new List<UserViewModel>();
                var customer = _IInvoicesService.GetInvoices(userViewModel);
                userList.AddRange(customer);
                response.Result = userList;
                response.APIResponse.ResponseCode = "000";

            }
            catch (Exception exp)
            {

            }
            return Json(response);
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(UserViewModel))]
        public JsonResult<CustomerResultResponse> GetExtract([FromBody] UserViewModel userViewModel)
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {
                List<UserViewModel> userList = new List<UserViewModel>();
                var customer = _IInvoicesService.GetExtract(userViewModel);
                userList.AddRange(customer);
                response.Result = userList;
                response.APIResponse.ResponseCode = "000";

            }
            catch (Exception exp)
            {

            }
            return Json(response);
        }
    }
}
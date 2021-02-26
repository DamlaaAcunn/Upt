using System;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using UPT.Entities;
using UPT.Helpers;
using UPT.Services;
namespace UPTWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: Customer
        private readonly ICustomerService _ICustomerService;
        public CustomerController(ICustomerService loginService)
        {
            _ICustomerService = loginService;
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(CustomerController))]
        public JsonResult<CustomerResultResponse> InsertCustomer([FromBody] UserViewModel userViewModel)
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {
                List<UserViewModel> userList = new List<UserViewModel>();
                _ICustomerService.InsertCustomer(userViewModel);
                response.APIResponse.ResponseCode = "000";

            }
            catch (Exception excp)
            {

            }
            return null;
        }
        [HttpGet]
        [JSONFilter(RootType = typeof(CustomerController))]
        public JsonResult<CustomerResultResponse> GetCustomer()
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {               
                List<UserViewModel> userList = new List<UserViewModel>();
                var customer = _ICustomerService.GetCustomer();
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
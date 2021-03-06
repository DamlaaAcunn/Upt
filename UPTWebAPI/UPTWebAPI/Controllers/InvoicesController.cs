﻿using System;
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
            {//İnsert Update gibi işlemleri yaparken validasyon kontrollerini view kısmında html editor kullanarak yapar kontrolden geçtikten sonra
                // servisi çağırmasını sağlardım.
                _IInvoicesService.InsertInvoices();
                response.APIResponse.ResponseCode = "000";
            }
            catch (Exception exc)
            {
                Console.Write(exc.Message);
            }
            return Json(response);
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(InvoicesController))]
        public JsonResult<CustomerResultResponse> CreateExtract()
        {
            CustomerResultResponse response = new CustomerResultResponse();
            try
            {//Ay sonu ekstre kesilme işlemi için yazılan api
                _IInvoicesService.CreateExtract();
                response.APIResponse.ResponseCode = "000";
            }
            catch (Exception exc)
            {
                Console.Write(exc.Message);
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
                Console.Write(exp.Message);
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
                Console.Write(exp.Message);
            }
            return Json(response);
        }
    }
}
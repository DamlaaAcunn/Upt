using System;
using System.Web.Http;
using System.Web.Http.Results;
using UPT.Entities;
using UPT.Helpers;
using UPT.Services;

namespace UPTWebAPI.Controllers
{
    public class LoginController : ApiController
    {
        // GET: Login
        private readonly ILoginService _ILoginService;
        public LoginController(ILoginService loginService)
        {
            _ILoginService = loginService;
        }
        [HttpPost]
        [JSONFilter(RootType = typeof(UserViewModel))]
        public UserViewModel GetUsers([FromBody] UserViewModel userViewModel)
        {
            try
            {
                var result = _ILoginService.GetUsers(userViewModel);

                return result;
            }
            catch (Exception excp)
            {

            }
            return null;
        }
    }
}
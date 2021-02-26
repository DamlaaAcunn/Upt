using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPT.Entities;
using UPT.Model;

namespace UPTWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUser(string UserName, string Password)
        {

            var login = new UserViewModel();
            using (UPTEntities dbContext = new UPTEntities())
            {
                var user = dbContext.Users.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
                if (user != null)
                {
                    login.RoleID = user.RoleID;
                    login.UserName = user.UserName;
                    login.Password = user.Password;
                    login.UserId = user.UserID;
                    Session["UserID"] = user.UserID;
                }

            }
            return Json(login, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AdminPanel()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Customer()
        {

            return View();
        }

    }
}

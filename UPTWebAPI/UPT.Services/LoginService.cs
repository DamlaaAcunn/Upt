using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;

namespace UPT.Services
{
    public class LoginService : ILoginService
    {
        public UserViewModel GetUsers(UserViewModel userViewModel)
        {

            var login = new UserViewModel();
            using (UPTEntities dbContext = new UPTEntities())
            {
                var user = dbContext.Users.Where(x=> x.UserName == userViewModel.UserName && x.Password == userViewModel.Password).FirstOrDefault();
                if (user != null)
                {
                    login.RoleID = user.RoleID;
                    login.UserName = user.UserName;
                    login.Password = user.Password;
                    login.RoleID = user.UserID;
                }
               
            }
            return login;
        }
    }
}

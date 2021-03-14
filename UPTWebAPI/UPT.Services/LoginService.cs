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
    {// Database bağlantısını normalde bu şekilde değilde tek bir nesneye dayalı mesela design pattern singleton uygun bir yapı kurar ve
       // tek bir instance üzerinden çağırabileceğim bir yapı oluştururdum.

       // private readonly Class _class;

        public LoginService(/* Class _ClassName*/)
        {
           // Ve constructer bu şekilde çağırırdım.

            //_class = _ClassName;
        }

        public UserViewModel GetUsers(UserViewModel userViewModel)
        {
            var login = new UserViewModel();
            try
            {
                using (UPTEntities dbContext = new UPTEntities())
                {
                    var user = dbContext.Users.Where(x => x.UserName == userViewModel.UserName && x.Password == userViewModel.Password).FirstOrDefault();
                    if (user != null)
                    {
                        login.RoleID = user.RoleID;
                        login.UserName = user.UserName;
                        login.Password = user.Password;
                        login.RoleID = user.UserID;
                    }

                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
         
            return login;
        }
    }
}

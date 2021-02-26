using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;


namespace UPT.Services
{
    public class UserService : IUserService
    {
        public Users UserInsert(UserViewModel userViewModel)
        {
            Users users = new Users();
            using (UPTEntities dbContext = new UPTEntities())
            {
                users.Password = "1234";
                users.RoleID = 1;
                users.UserName = userViewModel.UserName;
                users.Register = DateTime.Now;
                dbContext.Users.Add(users);
                dbContext.SaveChanges();
            }
            return users;
        }
    }
}

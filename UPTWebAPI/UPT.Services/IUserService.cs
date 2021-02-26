using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPT.Entities;
using UPT.Model;

namespace UPT.Services
{
    public interface IUserService
    {
        Users UserInsert(UserViewModel userViewModel);
    }
}

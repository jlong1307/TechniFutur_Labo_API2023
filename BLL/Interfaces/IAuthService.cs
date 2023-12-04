using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Forms.UserForms;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        User? Login(LoginUserForm form);
    }
}

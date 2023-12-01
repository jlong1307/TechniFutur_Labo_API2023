using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.DTO;
using BLL.Models.Forms.UserForms;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();

        UserDTO GetById(int id);

        //UserDTO GetByEmail(string email);

        UserDTO Create(CreateUserForm form);

        bool Update(int id, UpdateUserForm form);

        bool Delete(int id);

    }
}

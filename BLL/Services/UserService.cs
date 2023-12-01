using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public UserDTO Create(CreateUserForm form)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, UpdateUserForm form)
        {
            throw new NotImplementedException();
        }
    }
}

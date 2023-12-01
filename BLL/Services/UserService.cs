using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Mappers;
using BLL.Models.Forms.UserForms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDTO Create(CreateUserForm form)
        {
            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            form.Email = form.Email.ToLower();
            return _userRepository.Create(form.ToUser()).ToUserDTO();
        }

        public bool Delete(int id)
        {
            User? user = _userRepository.GetById(id);

            if (user is null)
                return false;
            return _userRepository.Delete(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _userRepository.GetAll().Select(x => x.ToUserDTO());
        }

        public UserDTO GetById(int id)
        {
            User? user = _userRepository.GetById(id);
            if (user is null)
                return null;
            return user.ToUserDTO();
        }

        public bool Update(int id, UpdateUserForm form)
        {
            User? user = _userRepository.GetById(id);
            if (user is null)
                return false;
            user.Id = form.Id;
            user.Email = form.Email.ToLower();
            user.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            user.NickName = form.NickName;
            user.FirstName = form.FirstName;
            user.LastName = form.LastName;
            user.BirthDate = form.BirthDate;
            user.Wallet = form.Wallet;
            user.Role = form.Role;
            user.Status = form.Status;
            return _userRepository.Update(user);
        }
    }
}

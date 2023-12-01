using BLL.Models.DTO;
using BLL.Models.Forms.UserForms;
using DAL.Entities;

namespace BLL.Mappers
{
    public static class ServicesMappers
    {
        //USER MAPPERS
        public static User ToUser(this CreateUserForm createUserForm)
        {
            return new User
            {
                Id = 0,
                Email = createUserForm.Email,
                Password = createUserForm.Password,
                NickName = createUserForm.Nickname,
                FirstName = createUserForm.FirstName,
                LastName = createUserForm.LastName,
                BirthDate = createUserForm.BirthDate,
                Wallet = 0,
                RegisterDate = DateTime.Now,
                Role = createUserForm.Role,
                Status = 0,
            };
        }

        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                NickName = user.NickName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Wallet = user.Wallet,
                RegisterDate = user.RegisterDate,
                Role = user.Role,
                Status = user.Status,
            };
        }

    }
}

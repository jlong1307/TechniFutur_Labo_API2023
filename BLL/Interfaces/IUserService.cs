using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.DTO;
using BLL.Models.Forms.FriendForm;
using BLL.Models.Forms.UserForms;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();

        UserDTO GetById(int id);

        UserDTO Create(CreateUserForm form);

        bool Update(int id, UpdateUserForm form);

        bool Delete(int id);
        IEnumerable<FriendDTO> GetAllFriend(int id);
        public FriendDTO CreateFriend(int id, CreateFriendForm form);
        public bool UpdateStatusFriend(int id, int status, UpdateFriendForm form);
        public bool UpdateUserPwrd(int id, UpdatePwrdForm form);
        public bool UpdateUserWallet(int id, UpdateWalletForm form);
        public bool UpdateUserNckname(int id, UpdateNckNameForm form);
    }
}

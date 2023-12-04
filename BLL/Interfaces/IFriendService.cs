using BLL.Models.DTO;
using BLL.Models.Forms.FriendForm;
using BLL.Models.Forms.GameForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFriendService
    {
        IEnumerable<FriendDTO> GetAll();

        FriendDTO GetById(int id);

        FriendDTO Create(CreateFriendForm form);

        bool Update(UpdateFriendForm form);

        bool Delete(UpdateFriendForm form);
    }
}

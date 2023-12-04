using BLL.Models.DTO;
using BLL.Models.Forms.GameForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGameService
    {
        IEnumerable<GameDTO> GetAll();

        GameDTO GetById(int id);

        GameDTO Create(CreateGameForm form);

        bool Update(int id, UpdateGameForm form);

        bool Delete(int id);
    }
}

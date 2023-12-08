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
        public IEnumerable<GameDTO> GetAllById(int id);

        GameDTO GetById(int id);

        GameDTO Create(int id, CreateGameForm form);

        bool Update(int id, UpdateGameForm form);

        bool Delete(int id);
    }
}

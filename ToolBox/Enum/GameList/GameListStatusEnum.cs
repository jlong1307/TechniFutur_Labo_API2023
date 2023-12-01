using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Enum.GameList
{
    public class GameListStatusEnum
    {
        enum GameListStatus
        {
            Offline = 0,
            Online = 1,
            Invalid = 2,
            refunded = 3,
        }
    }
}

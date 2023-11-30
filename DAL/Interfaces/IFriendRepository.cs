using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IFriendRepository :IRepository<int, Friend>
    {

    }
}

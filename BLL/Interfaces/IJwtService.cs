using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}

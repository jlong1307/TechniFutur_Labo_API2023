﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<int, User>
    {
        public User? GetByEmail(string email);
        public User? GetByNickName(string nickName);
    }
}

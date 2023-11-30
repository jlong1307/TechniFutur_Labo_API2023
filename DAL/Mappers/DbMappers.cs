using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class DbMappers
    {
        public static User ToUser(this SqlDataReader reader)
        {
            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Email = reader["Email"].ToString(),
                Nickname = reader["NickName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Age = Convert.ToInt32(reader["Age"]),
                Wallet = Convert.ToDouble(reader["Wallet"]),
                RegisterDate = Convert.ToDateTime(reader["RegisterDate"]),
                Role = Convert.ToInt32(reader["Role"]),
                Status = Convert.ToInt32(reader["Status"]),
            };
        }

        public static Game ToGame(this SqlDataReader reader)
        {
            return new Game
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Version = reader["Version"].ToString(),
                CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                UserIdDev = Convert.ToInt32(reader["UserIdDev"])
            };
        }

        public static Friend ToFriend(this SqlDataReader reader)
        {
            return new Friend
            {
                Status = Convert.ToInt32(reader["Id"]),
                UserIdRequester = Convert.ToInt32(reader["UserIdRequester"]),
                UserIdRequest = Convert.ToInt32(reader["UserIdRequest"]),
            };
        }
    }
}

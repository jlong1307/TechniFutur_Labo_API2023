using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using ToolBox.Database;
using ToolBox.Services;
namespace DAL.Repositories
{
    public class FriendRepository : Repository, IFriendRepository
    {
        public FriendRepository(string connectionString) : base(connectionString)
        {
        }

        public Friend? Create(Friend entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Friends VALUES(" +
                    "@Status," +
                    "@UserIdRequester," +
                    "@UserIdRequest";

                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@UserIdRequester", entity.UserIdRequester);
                cmd.Parameters.AddWithValue("@UserIdRequest", entity.UserIdRequest);
                if (cmd.CustomNonQuery(ConnectionString) == 1)
                    return entity;
                else
                    return null;
            }
        }

        public bool Delete(Friend entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Friends SET @Status = 2 " +
                                    "WHERE UserIdRequester = @UserIdRequester," +
                                           "UserIdRequest = @UserIdRequest";

                cmd.Parameters.AddWithValue("@UserIdRequester", entity.UserIdRequester);
                cmd.Parameters.AddWithValue("@UserIdRequest", entity.UserIdRequest);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public IEnumerable<Friend> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Friend";
                return cmd.CustomReader(ConnectionString, x => DbMappers.ToFriend(x));
            }
        }

        public Friend? GetById(int UserIdRequester)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * FROM Friend WHERE UserIdRequester = @UserIdRequester";

                cmd.Parameters.AddWithValue("UserIdRequester", UserIdRequester);

                return cmd.CustomReader(ConnectionString, x => DbMappers.ToFriend(x)).SingleOrDefault();
            }
        }

        public bool Update(Friend entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Game SET " +
                                                "@Status," +
                                                "@UserIdRequester," +
                                                "@UserIdRequest";

                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@UserIdRequester", entity.UserIdRequester);
                cmd.Parameters.AddWithValue("@UserIdRequest", entity.UserIdRequest);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}

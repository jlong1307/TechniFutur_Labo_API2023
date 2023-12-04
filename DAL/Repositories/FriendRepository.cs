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
    /// <summary>
    /// Represents a repository for managing Friend entities in the database.
    /// </summary>
    public class FriendRepository : Repository, IFriendRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FriendRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public FriendRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Creates a new Friend entity in the database.
        /// </summary>
        /// <param name="entity">The Friend entity to be created.</param>
        /// <returns>The created Friend entity if the creation is successful; otherwise, null.</returns>
        public Friend? Create(Friend entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Friends VALUES(" +
                    "@Status," +
                    "@UserIdRequester," +
                    "@UserIdRequest)";

                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@UserIdRequester", entity.UserIdRequester);
                cmd.Parameters.AddWithValue("@UserIdRequest", entity.UserIdRequest);

                if (cmd.CustomNonQuery(ConnectionString) == 1)
                    return entity;
                else
                    return null;
            }
        }

        /// <summary>
        /// Deletes a Friend entity from the database.
        /// </summary>
        /// <param name="entity">The Friend entity to be deleted.</param>
        /// <returns>True if the deletion is successful; otherwise, false.</returns>
        public bool Delete(Friend entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Friends SET Status = @Status " +
                                    "WHERE UserIdRequester = @UserIdRequester AND UserIdRequest = @UserIdRequest";

                cmd.Parameters.AddWithValue("@Status", 2);
                cmd.Parameters.AddWithValue("@UserIdRequester", entity.UserIdRequester);
                cmd.Parameters.AddWithValue("@UserIdRequest", entity.UserIdRequest);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        /// <summary>
        /// Retrieves all Friend entities from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of Friend entities.</returns>
        public IEnumerable<Friend> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Friends";
                return cmd.CustomReader(ConnectionString, x => DbMappers.ToFriend(x));
            }
        }

        /// <summary>
        /// Retrieves a Friend entity from the database based on the UserIdRequester.
        /// </summary>
        /// <param name="UserIdRequester">The identifier of the Friend entity to retrieve.</param>
        /// <returns>The retrieved Friend entity, or null if not found.</returns>
        public Friend? GetById(int UserIdRequester)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Friends WHERE UserIdRequester = @UserIdRequester";

                cmd.Parameters.AddWithValue("UserIdRequester", UserIdRequester);

                return cmd.CustomReader(ConnectionString, x => DbMappers.ToFriend(x)).SingleOrDefault();
            }
        }

        public Friend? GetByIds(int firstId, int secondId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Friends WHERE UserIdRequester = @UserIdRequester and UserIdRequest = @UserIdRequest";

                cmd.Parameters.AddWithValue("UserIdRequester", firstId);
                cmd.Parameters.AddWithValue("UserIdRequest", secondId);


                return cmd.CustomReader(ConnectionString, x => DbMappers.ToFriend(x)).SingleOrDefault();
            }
        }
        /// <summary>
        /// Updates a Friend entity in the database.
        /// </summary>
        /// <param name="entity">The Friend entity to be updated.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        public bool Update(Friend entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Friends SET " +
                    "Status = @Status," +
                    "UserIdRequester = @UserIdRequester," +
                    "UserIdRequest = @UserIdRequest";

                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@UserIdRequester", entity.UserIdRequester);
                cmd.Parameters.AddWithValue("@UserIdRequest", entity.UserIdRequest);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}

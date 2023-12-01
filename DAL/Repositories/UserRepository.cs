using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;
using ToolBox.Database;
using DAL.Mappers;

namespace DAL.Repositories
{
    /// <summary>
    /// Repository for performing CRUD operations on the 'Users' table in the database.
    /// </summary>
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {

        }
        /// <summary>
        /// Creates a new user record in the 'Users' table.
        /// </summary>
        /// <param name="entity">The user entity to be created.</param>
        /// <returns>The created user entity with the assigned identifier.</returns>
        public User? Create(User entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Users OUTPUT inserted.id VALUES(" +
                    "@Email," +
                    "@Password," +
                    "@NickName," +
                    "@FirstName," +
                    "@LastName," +
                    "@BirthDate," +
                    "@Wallet," +
                    "@RegisterDate," +
                    "@Role," +
                    "@Status)";

                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Password", entity.Password);
                cmd.Parameters.AddWithValue("@NickName", entity.Nickname);
                cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                cmd.Parameters.AddWithValue("@Wallet", entity.Wallet);
                cmd.Parameters.AddWithValue("@RegisterDate", entity.RegisterDate);
                cmd.Parameters.AddWithValue("@Role", entity.Role);
                cmd.Parameters.AddWithValue("@Status", entity.Status);

                int insertedId = Convert.ToInt32(cmd.CustomScalar(ConnectionString));
                entity.Id = insertedId;

                return entity;
            }
        }
        /// <summary>
        /// Deletes a user record in the 'Users' table by setting its status to '2'.
        /// </summary>
        /// <param name="entity">The user entity to be deleted.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public bool Delete(User entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Users SET Status = @Status WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Status", 2);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
        /// <summary>
        /// Retrieves all user records from the 'Users' table.
        /// </summary>
        /// <returns>A collection of user entities.</returns>
        public IEnumerable<User> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Users";
                return cmd.CustomReader(ConnectionString, x => DbMappers.ToUser(x));
            }
        }
        /// <summary>
        /// Retrieves a user record from the 'Users' table based on the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the user to retrieve.</param>
        /// <returns>The user entity with the specified identifier, or null if not found.</returns>
        public User? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * FROM Users WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", id);

                return cmd.CustomReader(ConnectionString, x => DbMappers.ToUser(x)).SingleOrDefault();
            }
        }
        /// <summary>
        /// Updates an existing user record in the 'Users' table.
        /// </summary>
        /// <param name="entity">The user entity with updated information.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public bool Update(User entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Users SET " +
                                                "Email = @Email," +
                                                "Password = @Password," +
                                                "NickName = @NickName," +
                                                "FirstName = @FirstName," +
                                                "LastName = @LastName," +
                                                "BirthDate = @BirthDate," +
                                                "Wallet = @Wallet," +
                                                "RegisterDate = @RegisterDate," +
                                                "Role = @Role," +
                                                "Status = @Status)";

                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Password", entity.Password);
                cmd.Parameters.AddWithValue("@NickName", entity.Nickname);
                cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                cmd.Parameters.AddWithValue("@Wallet", entity.Wallet);
                cmd.Parameters.AddWithValue("@RegisterDate", entity.RegisterDate);
                cmd.Parameters.AddWithValue("@Role", entity.Role);
                cmd.Parameters.AddWithValue("@Status", entity.Status);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}

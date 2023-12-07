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
    public class GameRepository : Repository, IGameRepository
    {
        /// <summary>
        /// Repository for performing CRUD operations on the 'Game' table in the database.
        /// </summary>
        public GameRepository(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// Creates a new game record in the 'Game' table.
        /// </summary>
        /// <param name="entity">The game entity to be created.</param>
        /// <returns>The created game entity with the assigned identifier.</returns>
        public Game? Create(Game entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Game OUTPUT inserted.Id VALUES(" +
                    "@Name," +
                    "@Version," +
                    "@CreationDate," +
                    "@UserIdDev," +
                    "@Status)";

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Version", entity.Version);
                cmd.Parameters.AddWithValue("@CreationDate", entity.CreationDate);
                cmd.Parameters.AddWithValue("@UserIdDev", entity.UserIdDev);
                cmd.Parameters.AddWithValue("@Status", entity.Status);

                int insertedId = Convert.ToInt32(cmd.CustomScalar(ConnectionString));
                entity.Id = insertedId;
                return entity;
            }
        }
        /// <summary>
        /// Deletes a game record in the 'Game' table by setting its status to '2'.
        /// </summary>
        /// <param name="entity">The game entity to be deleted.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public bool Delete(Game entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Game SET Status = @Status WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Status", 2);
                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
        /// <summary>
        /// Retrieves all game records from the 'Game' table.
        /// </summary>
        /// <returns>A collection of game entities.</returns>
        public IEnumerable<Game> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Game";
                return cmd.CustomReader(ConnectionString, x => DbMappers.ToGame(x));
            }
        }
        /// <summary>
        /// Retrieves a game record from the 'Game' table based on the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the game to retrieve.</param>
        /// <returns>The game entity with the specified identifier, or null if not found.</returns>
        public Game? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * FROM Game WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", id);

                return cmd.CustomReader(ConnectionString, x => DbMappers.ToGame(x)).SingleOrDefault();
            }
        }
        /// <summary>
        /// Updates an existing game record in the 'Game' table.
        /// </summary>
        /// <param name="entity">The game entity with updated information.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public bool Update(Game entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Game SET " +
                                                "Name = @Name," +
                                                "Version = @Version," +
                                                "CreationDate = @CreationDate," +
                                                "UserIdDev = @UserIdDev," +
                                                "Status = @Status WHERE Id = @id";

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Version", entity.Version);
                cmd.Parameters.AddWithValue("@CreationDate", entity.CreationDate);
                cmd.Parameters.AddWithValue("@UserIdDev", entity.UserIdDev);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@id", entity.Id);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}

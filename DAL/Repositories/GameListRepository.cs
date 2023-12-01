using DAL.Entities;
using DAL.Interfaces;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using ToolBox.Services;

namespace DAL.Repositories
{
    /// <summary>
    /// Represents a repository for managing GameList entities in the database.
    /// </summary>
    public class GameListRepository : Repository, IGameListRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameListRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public GameListRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Creates a new GameList entity in the database.
        /// </summary>
        /// <param name="entity">The GameList entity to be created.</param>
        /// <returns>The created GameList entity with the assigned identifier.</returns>
        public GameList? Create(GameList entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO GameList OUTPUT inserted.id VALUES(" +
                    "@UserId," +
                    "@GameId," +
                    "@PurchaseDate," +
                    "@PlayTime, " +
                    "@Status, " +
                    "@GiftUserId)";

                cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                cmd.Parameters.AddWithValue("@GameId", entity.GameId);
                cmd.Parameters.AddWithValue("@PurchaseDate", entity.PurchaseDate);
                cmd.Parameters.AddWithValue("@PlayTime", entity.PlayTime);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@GiftUserId", entity.GiftUserId);

                int insertedId = Convert.ToInt32(cmd.CustomScalar(ConnectionString));
                entity.Id = insertedId;
                return entity;
            }
        }

        /// <summary>
        /// Deletes a GameList entity from the database.
        /// </summary>
        /// <param name="entity">The GameList entity to be deleted.</param>
        /// <returns>True if the deletion is successful; otherwise, false.</returns>
        public bool Delete(GameList entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE GameList SET Status = @Status WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Status", 2);
                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        /// <summary>
        /// Retrieves all GameList entities from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of GameList entities.</returns>
        public IEnumerable<GameList> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM GameList";
                return cmd.CustomReader(ConnectionString, x => DbMappers.ToGameList(x));
            }
        }

        /// <summary>
        /// Retrieves a GameList entity from the database based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the GameList entity to retrieve.</param>
        /// <returns>The retrieved GameList entity, or null if not found.</returns>
        public GameList? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM GameList WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", id);

                return cmd.CustomReader(ConnectionString, x => DbMappers.ToGameList(x)).SingleOrDefault();
            }
        }

        /// <summary>
        /// Updates a GameList entity in the database.
        /// </summary>
        /// <param name="entity">The GameList entity to be updated.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        public bool Update(GameList entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE GameList SET " +
                    "UserId = @UserId," +
                    "GameId = @GameId," +
                    "PurchaseDate = @PurchaseDate," +
                    "PlayTime = @PlayTime, " +
                    "Status = @Status, " +
                    "GiftUserId = @GiftUserId";

                cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                cmd.Parameters.AddWithValue("@GameId", entity.GameId);
                cmd.Parameters.AddWithValue("@PurchaseDate", entity.PurchaseDate);
                cmd.Parameters.AddWithValue("@PlayTime", entity.PlayTime);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                cmd.Parameters.AddWithValue("@GiftUserId", entity.GiftUserId);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}

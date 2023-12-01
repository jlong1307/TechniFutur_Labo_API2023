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
    /// Represents a repository for managing Prices entities in the database.
    /// </summary>
    public class PriceRepository : Repository, IPriceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public PriceRepository(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Creates a new Prices entity in the database.
        /// </summary>
        /// <param name="entity">The Prices entity to be created.</param>
        /// <returns>The created Prices entity with the assigned identifier.</returns>
        public Prices? Create(Prices entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Prices OUTPUT inserted.id VALUES(" +
                    "@GameId," +
                    "@PriceDate," +
                    "@Price)";

                cmd.Parameters.AddWithValue("@GameId", entity.GameId);
                cmd.Parameters.AddWithValue("@PriceDate", entity.PriceDate);
                cmd.Parameters.AddWithValue("@Price", entity.Price);

                int insertedId = Convert.ToInt32(cmd.CustomScalar(ConnectionString));
                entity.Id = insertedId;
                return entity;
            }
        }

        /// <summary>
        /// Deletes a Prices entity from the database.
        /// </summary>
        /// <param name="entity">The Prices entity to be deleted.</param>
        /// <returns>True if the deletion is successful; otherwise, false.</returns>
        public bool Delete(Prices entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Prices WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", entity.Id);
                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        /// <summary>
        /// Retrieves all Prices entities from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of Prices entities.</returns>
        public IEnumerable<Prices> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Prices";
                return cmd.CustomReader(ConnectionString, x => DbMappers.ToPrices(x));
            }
        }

        /// <summary>
        /// Retrieves a Prices entity from the database based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the Prices entity to retrieve.</param>
        /// <returns>The retrieved Prices entity, or null if not found.</returns>
        public Prices? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Prices WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", id);

                return cmd.CustomReader(ConnectionString, x => DbMappers.ToPrices(x)).SingleOrDefault();
            }
        }

        /// <summary>
        /// Updates a Prices entity in the database.
        /// </summary>
        /// <param name="entity">The Prices entity to be updated.</param>
        /// <returns>True if the update is successful; otherwise, false.</returns>
        public bool Update(Prices entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Prices SET " +
                    "GameId = @GameId," +
                    "PriceDate = @PriceDate," +
                    "Price = @Price";

                cmd.Parameters.AddWithValue("@GameId", entity.GameId);
                cmd.Parameters.AddWithValue("@PriceDate", entity.PriceDate);
                cmd.Parameters.AddWithValue("@Price", entity.Price);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}

using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    /// <summary>
    /// Provides extension methods for mapping SqlDataReader data to User objects.
    /// </summary>
    public static class DbMappers
    {
        /// <summary>
        /// Converts SqlDataReader data to a User object.
        /// </summary>
        /// <param name="reader">The SqlDataReader containing the data.</param>
        /// <returns>A User object populated with data from the SqlDataReader.</returns>
        public static User ToUser(this SqlDataReader reader)
        {
            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                NickName = reader["NickName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                Wallet = Convert.ToDouble(reader["Wallet"]),
                RegisterDate = Convert.ToDateTime(reader["RegisterDate"]),
                Role = Convert.ToInt32(reader["Role"]),
                Status = Convert.ToInt32(reader["Status"]),
            };
        }

        /// <summary>
        /// Converts SqlDataReader data to a Game object.
        /// </summary>
        /// <param name="reader">The SqlDataReader containing the data.</param>
        /// <returns>A Game object populated with data from the SqlDataReader.</returns>
        public static Game ToGame(this SqlDataReader reader)
        {
            return new Game
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Version = reader["Version"].ToString(),
                CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                UserIdDev = Convert.ToInt32(reader["UserIdDev"]),
                Status = Convert.ToInt32(reader["Status"]),
            };
        }

        /// <summary>
        /// Converts SqlDataReader data to a Friend object.
        /// </summary>
        /// <param name="reader">The SqlDataReader containing the data.</param>
        /// <returns>A Friend object populated with data from the SqlDataReader.</returns>
        public static Friend ToFriend(this SqlDataReader reader)
        {
            return new Friend
            {
                Status = Convert.ToInt32(reader["Id"]),
                UserIdRequester = Convert.ToInt32(reader["UserIdRequester"]),
                UserIdRequest = Convert.ToInt32(reader["UserIdRequest"]),
            };
        }

        /// <summary>
        /// Converts SqlDataReader data to a GameList object.
        /// </summary>
        /// <param name="reader">The SqlDataReader containing the data.</param>
        /// <returns>A GameList object populated with data from the SqlDataReader.</returns>
        public static GameList ToGameList(this SqlDataReader reader)
        {
            return new GameList
            {
                Id = Convert.ToInt32(reader["Id"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                GameId = Convert.ToInt32(reader["GameId"]),
                PurchaseDate = Convert.ToDateTime(reader["PurchaseDate"]),
                PlayTime = Convert.ToInt32(reader["PlayTime"]),
                Status = Convert.ToInt32(reader["Status"]),
                GiftUserId = Convert.ToInt32(reader["GiftUserId"]),
            };
        }

        /// <summary>
        /// Converts SqlDataReader data to a Prices object.
        /// </summary>
        /// <param name="reader">The SqlDataReader containing the data.</param>
        /// <returns>A Prices object populated with data from the SqlDataReader.</returns>
        public static Prices ToPrices(this SqlDataReader reader)
        {
            return new Prices
            {
                Id = Convert.ToInt32(reader["Id"]),
                GameId = Convert.ToInt32(reader["GameId"]),
                PriceDate = Convert.ToDateTime(reader["PriceDate"]),
                Price = Convert.ToInt32(reader["Price"]),
            };
        }
    }

}

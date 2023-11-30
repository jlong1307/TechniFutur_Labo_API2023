using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// Represents a record in the game list, tracking information such as user ID, game ID, purchase date, playtime, status, and gift user ID.
    /// </summary>
    public class GameList
    {
        /// <summary>
        /// Gets or sets the unique identifier for the game list entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the game list entry.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the game ID associated with the game list entry.
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets the date when the game was purchased.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the playtime recorded for the game.
        /// </summary>
        public int PlayTime { get; set; }

        /// <summary>
        /// Gets or sets the status of the game (e.g., completed, in-progress, etc.).
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the person who gifted the game (if applicable).
        /// </summary>
        public int GiftUserId { get; set; }
    }

}

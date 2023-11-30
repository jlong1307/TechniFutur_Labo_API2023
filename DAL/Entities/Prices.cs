using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// Represents the pricing information for a game, including the unique identifier, game ID,
    /// price date, and the associated price.
    /// </summary>
    public class Prices
    {
        /// <summary>
        /// Gets or sets the unique identifier for the pricing entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the game ID associated with the pricing entry.
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets the date when the price was recorded.
        /// </summary>
        public DateTime PriceDate { get; set; }

        /// <summary>
        /// Gets or sets the price of the game.
        /// </summary>
        public double Price { get; set; }
    }
}

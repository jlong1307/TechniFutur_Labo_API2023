using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;

namespace DAL.Entities
{
    /// <summary>
    /// Represents a game in the database with details such as ID, name, version, creation date, and developer user ID.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the unique identifier for the game in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the game in the database.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version of the game in the database.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the date when the game was created in the database.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the developer who created the game.
        /// </summary>
        public int UserIdDev { get; set; }
    }

}

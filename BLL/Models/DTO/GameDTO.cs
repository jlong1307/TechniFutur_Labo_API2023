using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for game information.
    /// </summary>
    public class GameDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the game.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the game.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version of the game.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the game.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the user identifier of the game developer.
        /// </summary>
        public int UserIdDev { get; set; }

        /// <summary>
        /// Gets or sets the status identifier of the game.
        /// </summary>
        public int Status { get; set; }
    }

}

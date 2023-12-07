using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.GameForms
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a new game.
    /// </summary>
    public class CreateGameForm
    {
        /// <summary>
        /// Gets or sets the name of the new game.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version of the new game.
        /// </summary>
        public string Version { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.GameForms
{
    /// <summary>
    /// Represents a form for updating the version of a game.
    /// </summary>
    public class UpdateVersionGameForm
    {
        /// <summary>
        /// Gets or sets the name of the game.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the new version of the game.
        /// </summary>
        public string NewVersion { get; set; }
    }

}

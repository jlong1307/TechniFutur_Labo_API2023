using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.GameForms
{
    public class CreateGameRelationForm
    {

        /// <summary>
        /// Gets or sets the game ID associated with the game list entry.
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the person who gifted the game (if applicable).
        /// </summary>
        public int GiftUserId { get; set; }
    }
}

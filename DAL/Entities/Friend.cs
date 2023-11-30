using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;

namespace DAL.Entities
{
    /// <summary>
    /// Represents a friend request with details such as the ID of the user making the request, 
    /// the ID of the user who received the request, and the status of the request.
    /// </summary>
    public class Friend
    {
        /// <summary>
        /// Gets or sets the ID of the user making the friend request.
        /// </summary>
        public int UserIdRequester { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who received the friend request.
        /// </summary>
        public int UserIdRequest { get; set; }

        /// <summary>
        /// Gets or sets the status of the friend request, based on an enum in the Toolbox.Enum.Friend.
        /// </summary>
        public int Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) representing friend-related information.
    /// </summary>
    public class FriendDTO
    {
        /// <summary>
        /// Gets or sets the status of the friend relationship.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the nickname of the user who sent the friend request.
        /// </summary>
        public string UserNickNameRequester { get; set; }

        /// <summary>
        /// Gets or sets the nickname of the user who received the friend request.
        /// </summary>
        public string UserNickNameRequest { get; set; }
    }

}

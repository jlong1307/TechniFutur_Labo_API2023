using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.UserForms
{
    /// <summary>
    /// Represents a data transfer object (DTO) for user login information.
    /// </summary>
    public class LoginUserForm
    {
        /// <summary>
        /// Gets or sets the email address of the user for login.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user for login.
        /// </summary>
        public string Password { get; set; }
    }

}

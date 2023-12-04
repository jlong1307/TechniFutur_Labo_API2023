using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.UserForms
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a new user.
    /// </summary>
    public class CreateUserForm
    {
        /// <summary>
        /// Gets or sets the email address of the new user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the new user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the nickname of the new user.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the first name of the new user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the new user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the role identifier of the new user.
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the new user.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}

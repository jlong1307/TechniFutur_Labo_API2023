using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for user information.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the nickname of the user.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the user.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the wallet balance of the user.
        /// </summary>
        public double Wallet { get; set; }

        /// <summary>
        /// Gets or sets the registration date of the user.
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// Gets or sets the role identifier of the user.
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the status identifier of the user.
        /// </summary>
        public int Status { get; set; }
    }

}

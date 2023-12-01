using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// Represents a user in the database with details such as ID, email, nickname, first name, last name, age, wallet, 
    /// register date, role, and status.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the email of the user in the database.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the Password of the user in the database.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the nickname of the user in the database.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user in the database.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user in the database.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the age of the user in the database.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of money in the user's wallet in the database.
        /// </summary>
        public double Wallet { get; set; }

        /// <summary>
        /// Gets or sets the register date of the user in the database.
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// Gets or sets the role of the user in the database, based on an enum in the Toolbox.Enum.User.
        /// </summary>
        public int Role { get; set; } // Consider using an enum for better type safety

        /// <summary>
        /// Gets or sets the status of the user in the database, based on an enum in the Toolbox.Enum.User.
        /// </summary>
        public int Status { get; set; } // Consider using an enum for better type safety
    }
}

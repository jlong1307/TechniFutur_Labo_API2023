using BLL.Interfaces;
using BLL.Models.Forms.UserForms;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the AuthService class.
        /// </summary>
        /// <param name="userRepo">The repository for user-related data access.</param>
        public AuthService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        /// <summary>
        /// Attempts to authenticate a user based on the provided LoginUserForm.
        /// </summary>
        /// <param name="form">The LoginUserForm containing user login information.</param>
        /// <returns>
        /// The authenticated user if login is successful, null if the user is not found
        /// or the password verification fails.
        /// </returns>
        public User? Login(LoginUserForm form)
        {
            // Retrieve the user from the repository based on the provided email.
            User? user = _userRepository.GetByEmail(form.Email);

            // If the user does not exist, return null.
            if (user is null)
            {
                return null;
            }

            // Verify the provided password against the stored hashed password.
            if (BCrypt.Net.BCrypt.Verify(form.Password, user.Password))
            {
                // Return the authenticated user.
                return user;
            }

            // Return null if the password verification fails.
            return null;
        }
    }
}

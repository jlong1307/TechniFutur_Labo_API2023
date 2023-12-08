using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using BLL.Interfaces;
using BLL.Models.Forms.UserForms;
using DAL.Entities;

namespace ApiSteam.Controllers
{
    /// <summary>
    /// API controller for handling authentication-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        /// <summary>
        /// Initializes a new instance of the AuthController class.
        /// </summary>
        /// <param name="authService">The service responsible for authentication operations.</param>
        /// <param name="jwtService">The service responsible for JWT token creation.</param>
        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Handles user login and returns a JWT token upon successful authentication.
        /// </summary>
        /// <param name="form">The LoginUserForm containing user login information.</param>
        /// <returns>An action result containing a JWT token or BadRequest if the login is unsuccessful.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginUserForm form)
        {
            User? user = _authService.Login(form);

            if (user is null)
            {
                return BadRequest();
            }

            return Ok(_jwtService.CreateToken(user));
        }
    }

}

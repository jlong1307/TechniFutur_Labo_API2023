using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using BLL.Interfaces;
using BLL.Models.Forms.UserForms;
using DAL.Entities;

namespace ApiSteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;

        }

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

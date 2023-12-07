using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms.FriendForm;
using BLL.Models.Forms.UserForms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiSteam.Controllers
{
    /// <summary>
    /// API controller for managing user-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the UserController class.
        /// </summary>
        /// <param name="userService">The service responsible for user-related operations.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>An action result containing a list of UserDTOs or BadRequest if unsuccessful.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UserDTO>> GetAll()
        {
            return Ok(_userService.GetAll());
        }
        [HttpGet("GetFriends")]
        public ActionResult<IEnumerable<FriendDTO>> GetFriends() 
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            return Ok(_userService.GetAllFriend(id));
        }
        /// <summary>
        /// Gets a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>An action result containing the UserDTO or BadRequest if the user is not found.</returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public ActionResult<UserDTO> GetById(int id)
        {
            UserDTO userDTO = _userService.GetById(id);

            return userDTO is null ? BadRequest() : Ok(userDTO);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="form">The CreateUserForm containing user information.</param>
        /// <returns>An action result containing the created UserDTO or BadRequest if unsuccessful.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserDTO> Create(CreateUserForm form)
        {
            UserDTO userDTO = _userService.Create(form);

            return userDTO is null ? BadRequest() : Ok(userDTO);
        }

        [HttpPost("FriendRequest")]
        public ActionResult<FriendDTO> FriendRequest(CreateFriendForm form)
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            FriendDTO friendDTO = _userService.CreateFriend(id, form);

            return friendDTO is null ? BadRequest() : Ok(friendDTO);
        }


        [HttpPatch("UpdatePwrd")]
        public IActionResult UpdatePwrd(UpdatePwrdForm form)
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            return _userService.UpdateUserPwrd(id, form) ? NoContent() : BadRequest();
        }

        [HttpPatch("UpdateNckName")]
        public IActionResult UpdateNckName(UpdateNckNameForm form)
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            return _userService.UpdateUserNckname(id, form) ? NoContent() : BadRequest();
        }

        [HttpPatch("UpdateWallet")]
        public IActionResult UpdateWallet(UpdateWalletForm form)
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            return _userService.UpdateUserWallet(id, form) ? NoContent() : BadRequest();
        }

        [HttpPatch("AcceptFriend")]
        public IActionResult AcceptFriend(UpdateFriendForm form)
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            return _userService.UpdateStatusFriend(id, 1, form) ? NoContent() : BadRequest();
        }

        [HttpPatch("DeleteFriend")]
        public IActionResult DeleteFriend(UpdateFriendForm form)
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            return _userService.UpdateStatusFriend(id, 2, form) ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="form">The UpdateUserForm containing updated user information.</param>
        /// <returns>NoContent if the update is successful, BadRequest otherwise.</returns>
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateUserForm form)
        {
            return _userService.Update(id, form) ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Deletes a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns>NoContent if the deletion is successful, BadRequest otherwise.</returns>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return _userService.Delete(id) ? NoContent() : BadRequest();
        }
    }

}

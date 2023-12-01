using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms.UserForms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            UserDTO userDTO = _userService.GetById(id);

            return userDTO is null ? BadRequest() : Ok(userDTO);
        }

        [HttpPost]
        public ActionResult<UserDTO> Create(CreateUserForm form)
        {
            UserDTO userDTO = _userService.Create(form);

            return userDTO is null ? BadRequest() : Ok(userDTO);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateUserForm form)
        {
            return _userService.Update(id, form) ? NoContent() : BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return _userService.Delete(id) ? NoContent() : BadRequest();
        }
    }
}

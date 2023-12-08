using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms.GameForms;
using BLL.Models.Forms.UserForms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiSteam.Controllers
{
    /// <summary>
    /// API controller for managing game-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        /// <summary>
        /// Initializes a new instance of the GameController class.
        /// </summary>
        /// <param name="gameService">The service responsible for game-related operations.</param>
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns>An action result containing a list of GameDTOs or BadRequest if unsuccessful.</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<GameDTO>> GetAll()
        {
            return Ok(_gameService.GetAll());
        }

        [HttpGet("GetAllByDev")]
        public ActionResult<IEnumerable<GameDTO>> GetAllByDev()
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            return Ok(_gameService.GetAllById(id));
        }

        /// <summary>
        /// Gets a game by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game.</param>
        /// <returns>An action result containing the GameDTO or BadRequest if the game is not found.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<GameDTO> GetById(int id)
        {
            GameDTO gameDTO = _gameService.GetById(id);

            return gameDTO is null ? BadRequest() : Ok(gameDTO);
        }

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="form">The CreateGameForm containing game information.</param>
        /// <returns>An action result containing the created GameDTO or BadRequest if unsuccessful.</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult<GameDTO> Create(CreateGameForm form)
        {
            var claim = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            int id = Convert.ToInt32(claim.Value);

            GameDTO gameDTO = _gameService.Create(id, form);

            return gameDTO is null ? BadRequest() : Ok(gameDTO);
        }

        /// <summary>
        /// Updates an existing game.
        /// </summary>
        /// <param name="id">The unique identifier of the game to update.</param>
        /// <param name="form">The UpdateGameForm containing updated game information.</param>
        /// <returns>NoContent if the update is successful, BadRequest otherwise.</returns>
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateGameForm form)
        {
            return _gameService.Update(id, form) ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Deletes a game by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the game to delete.</param>
        /// <returns>NoContent if the deletion is successful, BadRequest otherwise.</returns>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return _gameService.Delete(id) ? NoContent() : BadRequest();
        }
    }

}

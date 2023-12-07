using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.GameForms;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        /// <summary>
        /// Initializes a new instance of the GameService class.
        /// </summary>
        /// <param name="gameRepository">The repository for game-related data access.</param>
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        /// <summary>
        /// Creates a new game based on the provided CreateGameForm.
        /// </summary>
        /// <param name="form">The CreateGameForm containing game information.</param>
        /// <returns>The created game converted to a GameDTO.</returns>
        public GameDTO Create(int id, CreateGameForm form)
        {
            Game? game = form.ToGame();
            game.UserIdDev = id;

            return _gameRepository.Create(game).ToGameDTO();
        }

        /// <summary>
        /// Deletes a game by its ID.
        /// </summary>
        /// <param name="id">The ID of the game to delete.</param>
        /// <returns>True if the game was successfully deleted, false otherwise.</returns>
        public bool Delete(int id)
        {
            // Retrieve the game from the repository based on the provided ID.
            Game game = _gameRepository.GetById(id);

            // If the game does not exist, return false.
            if (game is null)
                return false;

            // Delete the game from the repository and return the result.
            return _gameRepository.Delete(game);
        }

        /// <summary>
        /// Gets all games and converts them to GameDTO.
        /// </summary>
        /// <returns>An IEnumerable of GameDTO representing all games.</returns>
        public IEnumerable<GameDTO> GetAll()
        {
            return _gameRepository.GetAll().Select(x => x.ToGameDTO());
        }

        public IEnumerable<GameDTO> GetAll(int id)
        {
            return _gameRepository.GetAll().Where(x => x.UserIdDev == id).Select(x => x.ToGameDTO());
        }

        /// <summary>
        /// Gets a game by its ID and converts it to GameDTO.
        /// </summary>
        /// <param name="id">The ID of the game to retrieve.</param>
        /// <returns>The GameDTO representation of the retrieved game or null if not found.</returns>
        public GameDTO GetById(int id)
        {
            // Retrieve the game from the repository based on the provided ID.
            Game game = _gameRepository.GetById(id);

            // If the game does not exist, return null.
            if (game is null)
                return null;

            // Convert the game to GameDTO before returning it.
            return game.ToGameDTO();
        }

        /// <summary>
        /// Updates an existing game based on the provided UpdateGameForm.
        /// </summary>
        /// <param name="id">The ID of the game to update.</param>
        /// <param name="form">The UpdateGameForm containing updated game information.</param>
        /// <returns>True if the game was successfully updated, false otherwise.</returns>
        public bool Update(int id, UpdateGameForm form)
        {
            // Retrieve the game from the repository based on the provided ID.
            Game game = _gameRepository.GetById(id);

            // If the game does not exist, return false.
            if (game is null)
                return false;

            // Update the game properties with the values from the provided form.
            game.Name = form.Name;
            game.Version = form.Version;
            game.CreationDate = form.CreationDate;
            game.UserIdDev = form.UserIdDev;
            game.Status = form.Status;

            // Update the game in the repository and return the result.
            return _gameRepository.Update(game);
        }
    }
}

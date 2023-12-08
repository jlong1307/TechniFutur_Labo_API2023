using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Mappers;
using BLL.Models.Forms.UserForms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.Identity.Client;
using BLL.Models.Forms.FriendForm;
using DAL.Repositories;
using BLL.Models.Forms.GameForms;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendRepository _friendRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IGameListRepository _gameListRepository;
        /// <summary>
        /// Constructor to initialize the UserService with an IUserRepository instance.
        /// </summary>
        public UserService(IUserRepository userRepository, IFriendRepository friendRepository, IGameRepository gameRepository, IGameListRepository gameListRepository)
        {
            _userRepository = userRepository;
            _friendRepository = friendRepository;
            _gameRepository = gameRepository;
            _gameListRepository = gameListRepository;
        }

        /// <summary>
        /// Creates a new user based on the provided CreateUserForm.
        /// </summary>
        /// <param name="form">The CreateUserForm containing user information.</param>
        /// <returns>The created user converted to a UserDTO.</returns>
        public UserDTO Create(CreateUserForm form)
        {
            foreach(User user in _userRepository.GetAll())
            {
                if (form.Email == user.Email)
                    return null;
                if (form.Nickname == user.NickName)
                    return null;
            }

            // Hash the password using BCrypt before saving it.
            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);

            // Convert email to lowercase for consistency.
            form.Email = form.Email.ToLower();

            // Create a new user using the provided form, save it in the repository,
            // and convert the result to a UserDTO before returning it.
            return _userRepository.Create(form.ToUser()).ToUserDTO();
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the user was successfully deleted, false otherwise.</returns>
        public bool Delete(int id)
        {
            // Retrieve the user from the repository based on the provided ID.
            User? user = _userRepository.GetById(id);

            // If the user does not exist, return false.
            if (user is null)
                return false;

            // Delete the user from the repository and return the result.
            return _userRepository.Delete(user);
        }

        /// <summary>
        /// Gets all users and converts them to UserDTO.
        /// </summary>
        /// <returns>An IEnumerable of UserDTO representing all users.</returns>
        public IEnumerable<UserDTO> GetAll()
        {
            // Retrieve all users from the repository, and convert each to UserDTO.
            return _userRepository.GetAll().Select(x => x.ToUserDTO());
        }

        /// <summary>
        /// Gets a user by their ID and converts it to UserDTO.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The UserDTO representation of the retrieved user or null if not found.</returns>
        public UserDTO GetById(int id)
        {
            // Retrieve the user from the repository based on the provided ID.
            User? user = _userRepository.GetById(id);

            // If the user does not exist, return null.
            if (user is null)
                return null;

            // Convert the user to UserDTO before returning it.
            return user.ToUserDTO();
        }

        /// <summary>
        /// Updates an existing user based on the provided UpdateUserForm.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="form">The UpdateUserForm containing updated user information.</param>
        /// <returns>True if the user was successfully updated, false otherwise.</returns>
        public bool Update(int id, UpdateUserForm form)
        {
            // Retrieve the user from the repository based on the provided ID.
            User? user = _userRepository.GetById(id);

            // If the user does not exist, return false.
            if (user is null)
                return false;

            // Update the user properties with the values from the provided form.
            user.Id = form.Id;
            user.Email = form.Email.ToLower();
            user.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            user.NickName = form.NickName;
            user.FirstName = form.FirstName;
            user.LastName = form.LastName;
            user.BirthDate = form.BirthDate;
            user.Wallet = form.Wallet;
            user.Role = form.Role;
            user.Status = form.Status;

            // Update the user in the repository and return the result.
            return _userRepository.Update(user);
        }

        /// <summary>
        /// Creates a friend connection between two users based on the provided form and user ID.
        /// </summary>
        /// <param name="id">The user ID initiating the friend request.</param>
        /// <param name="form">The form containing friend request details.</param>
        /// <returns>A FriendDTO if the friend connection is successfully created, otherwise null.</returns>
        public FriendDTO CreateFriend(int id, CreateFriendForm form)
        {
            User? firstUser = _userRepository.GetById(id);
            User? secondUser = _userRepository.GetByNickName(form.UserNickNameRequest);

            if (firstUser is null || secondUser is null || form is null)
                return null;

            foreach (Friend friend in _friendRepository.GetAll())
            {
                if (firstUser.Id == friend.UserIdRequester && secondUser.Id == friend.UserIdRequest ||
                    firstUser.Id == friend.UserIdRequest && secondUser.Id == friend.UserIdRequester)
                    return null;
            }

            Friend tmpFriend = new Friend
            {
                Status = 0,
                UserIdRequester = firstUser.Id,
                UserIdRequest = secondUser.Id,
            };
            return _friendRepository.Create(tmpFriend).ToFriendDTO(firstUser.NickName, secondUser.NickName);
        }

        /// <summary>
        /// Retrieves all friend connections for a given user ID.
        /// </summary>
        /// <param name="id">The user ID for which to retrieve friend connections.</param>
        /// <returns>An IEnumerable of FriendDTO representing all friend connections for the specified user.</returns>
        public IEnumerable<FriendDTO> GetAllFriend(int id)
        {
            return _friendRepository.GetAll().Where(x => x.UserIdRequester == id || x.UserIdRequest == id)
                                        .Select(x => x.ToFriendDTO(_userRepository.GetById(x.UserIdRequester).NickName,
                                                                    _userRepository.GetById(x.UserIdRequest).NickName));
        }

        /// <summary>
        /// Updates the status of a friend connection based on the provided form and user ID.
        /// </summary>
        /// <param name="id">The user ID initiating the status update.</param>
        /// <param name="status">The new status code for the friend connection.</param>
        /// <param name="form">The form containing details for updating the friend connection status.</param>
        /// <returns>True if the status update is successful, otherwise false.</returns>
        public bool UpdateStatusFriend(int id, int status, UpdateFriendForm form)
        {
            User? firstUser = _userRepository.GetById(id);
            User? secondUser = _userRepository.GetByNickName(form.UserIdRequester);

            if (firstUser is null || secondUser is null || form is null)
                return false;

            Friend tmpFriend = new Friend
            {
                Status = status,
                UserIdRequester = firstUser.Id,
                UserIdRequest = secondUser.Id,
            };
            return _friendRepository.Update(tmpFriend);
        }

        /// <summary>
        /// Updates the password of a user based on the provided form and user ID.
        /// </summary>
        /// <param name="id">The user ID for which to update the password.</param>
        /// <param name="form">The form containing the new password.</param>
        /// <returns>True if the password update is successful, otherwise false.</returns>
        public bool UpdateUserPwrd(int id, UpdatePwrdForm form)
        {
            User? user = _userRepository.GetById(id);

            if (user is null || form is null)
                return false;

            user.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);

            return _userRepository.Update(user);
        }
        /// <summary>
        /// Updates the wallet information of a user based on the provided form and user ID.
        /// </summary>
        /// <param name="id">The user ID for which to update the wallet information.</param>
        /// <param name="form">The form containing the new wallet information.</param>
        /// <returns>True if the wallet update is successful, otherwise false.</returns>
        public bool UpdateUserWallet(int id, UpdateWalletForm form)
        {
            User? user = _userRepository.GetById(id);

            if (user is null || form is null)
                return false;

            user.Wallet = form.Wallet;

            return _userRepository.Update(user);
        }
        /// <summary>
        /// Updates the nickname of a user based on the provided form and user ID.
        /// </summary>
        /// <param name="id">The user ID for which to update the nickname.</param>
        /// <param name="form">The form containing the new nickname.</param>
        /// <returns>True if the nickname update is successful, otherwise false.</returns>
        public bool UpdateUserNckname(int id, UpdateNckNameForm form)
        {
            User? user = _userRepository.GetById(id);

            if (user is null || form is null)
                return false;

            foreach(User u in _userRepository.GetAll())
                if (u.NickName == form.NewNckName)
                    return false;

            user.NickName = form.NewNckName;
            return _userRepository.Update(user);
        }

        public GameListDTO BuyGame(int id, CreateGameRelationForm form)
        {
            User? user = _userRepository.GetById(id);
            User? userB = _userRepository.GetById(form.GiftUserId);

            Game? game = _gameRepository.GetById(form.GameId);

            if (user is null && userB is null && game is null)
                return null;

            foreach(GameList gameList in _gameListRepository.GetAll())
            {
                if (gameList.GameId == form.GameId && gameList.GiftUserId == form.GiftUserId)
                    return null;
            }

            double price = _gameRepository.GetPrice(game.Name);

            if (user.Wallet < price)
                return null;

            UpdateUserWallet(user.Id, new UpdateWalletForm {Wallet = user.Wallet - price });

            return _gameListRepository.Create(form.ToGameList(id)).ToGameListDTO();
        }

        public IEnumerable<GameListDTO> GetMyGame(int id)
        {
            return _gameListRepository.GetAll().Where(x => x.GiftUserId == id)
                                        .Select(x => x.ToGameListDTO());
        }
    }
}

using BLL.Models.DTO;
using BLL.Models.Forms.FriendForm;
using BLL.Models.Forms.GameForms;
using BLL.Models.Forms.UserForms;
using DAL.Entities;

namespace BLL.Mappers
{
    /// <summary>
    /// Provides extension methods for mapping between different data transfer objects (DTOs) and entities.
    /// </summary>
    public static class ServicesMappers
    {
        /// <summary>
        /// Maps a CreateUserForm to a User entity.
        /// </summary>
        public static User ToUser(this CreateUserForm createUserForm)
        {
            return new User
            {
                Id = 0,
                Email = createUserForm.Email,
                Password = createUserForm.Password,
                NickName = createUserForm.Nickname,
                FirstName = createUserForm.FirstName,
                LastName = createUserForm.LastName,
                BirthDate = createUserForm.BirthDate,
                Wallet = 0,
                RegisterDate = DateTime.Now,
                Role = createUserForm.Role,
                Status = 0,
            };
        }

        /// <summary>
        /// Maps a User entity to a UserDTO.
        /// </summary>
        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                NickName = user.NickName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Wallet = user.Wallet,
                RegisterDate = user.RegisterDate,
                Role = user.Role,
                Status = user.Status,
            };
        }

        /// <summary>
        /// Maps a CreateGameForm to a Game entity.
        /// </summary>
        public static Game ToGame(this CreateGameForm createGameForm)
        {
            return new Game
            {
                Id = 0,
                Name = createGameForm.Name,
                Version = createGameForm.Version,
                CreationDate = DateTime.Now,
                UserIdDev = 0,
                Status = 1
                
            };
        }

        /// <summary>
        /// Maps a Game entity to a GameDTO.
        /// </summary>
        public static GameDTO ToGameDTO(this Game game)
        {
            return new GameDTO
            {
                Id = game.Id,
                Name = game.Name,
                Version = game.Version,
                CreationDate = game.CreationDate,
                UserIdDev = game.UserIdDev,
                Status = game.Status,
            };
        }
        
        public static Friend ToFriend(this CreateFriendForm createFriendForm, int n, int m)
        {
            return new Friend
            {
                Status = 0,
                UserIdRequest = n,
                UserIdRequester = m,
            };
        }


        public static FriendDTO ToFriendDTO(this Friend friend, string nckFirst, string nckSecond)
        {
            return new FriendDTO
            {
                Status = friend.Status,
                UserNickNameRequest = nckFirst,
                UserNickNameRequester = nckSecond,
            };
        }
    }
}

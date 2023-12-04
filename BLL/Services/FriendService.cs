using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.FriendForm;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserRepository _userRepository;
        public FriendService(IFriendRepository friendRepository, IUserRepository userRepository) 
        {
            _friendRepository = friendRepository;
            _userRepository = userRepository;
        }

        //public FriendDTO Create(CreateFriendForm form)
        //{
        //    User? firstUser = _userRepository.GetByNickName(form.UserNickNameRequester);
        //    User? secondUser = _userRepository.GetByNickName(form.UserNickNameRequest);

        //    if (firstUser is null || secondUser is null)
        //        return null;

        //    foreach (Friend friend in _friendRepository.GetAll())
        //    {
        //        if (firstUser.Id == friend.UserIdRequester && secondUser.Id == friend.UserIdRequest ||
        //            firstUser.Id == friend.UserIdRequest && secondUser.Id == friend.UserIdRequester)
        //            return null;
        //    }

        //    Friend tmpFriend = new Friend
        //    {
        //        Status = 0,
        //        UserIdRequester = firstUser.Id,
        //        UserIdRequest = secondUser.Id,
        //    };
        //    return _friendRepository.Create(tmpFriend).ToFriendDTO(firstUser.NickName, secondUser.NickName);
        //}

        //public bool Delete(UpdateFriendForm form)
        //{
        //    Friend friend = _friendRepository.GetByIds(form.UserIdRequester, form.UserIdRequest);
        //    if (friend is null)
        //        return false;
        //    return _friendRepository.Delete(friend);
        //}

        //public IEnumerable<FriendDTO> GetAll()
        //{
        //    return _friendRepository.GetAll().Select(x => x.ToFriendDTO());
        //}

        //public FriendDTO GetById(int id)
        //{
        //    Friend friend = _friendRepository.GetById(id);
        //    if (friend is null)
        //        return null;
        //    return friend.ToFriendDTO();
        //}

        //public bool Update(UpdateFriendForm form)
        //{
        //    Friend friend = _friendRepository.GetByIds(form.UserIdRequester, form.UserIdRequest);
        //    if (friend is null)
        //        return false;
        //    friend.Status = form.Status;
        //    friend.UserIdRequester = form.UserIdRequester;
        //    friend.UserIdRequest = form.UserIdRequest;

        //    return _friendRepository.Update(friend);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO
{
    public class FriendDTO
    {
        public int Status { get; set; }
        public string UserNickNameRequester { get; set; }
        public string UserNickNameRequest { get; set; }
    }
}

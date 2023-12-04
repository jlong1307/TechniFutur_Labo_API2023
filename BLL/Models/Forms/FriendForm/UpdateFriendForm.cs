using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.FriendForm
{
    public class UpdateFriendForm
    {
        public int Status { get; set; }
        public int UserIdRequester { get; set; }
        public int UserIdRequest { get; set; }
    }
}

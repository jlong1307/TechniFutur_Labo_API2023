using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.UserForms
{
    public class CreateUserForm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}

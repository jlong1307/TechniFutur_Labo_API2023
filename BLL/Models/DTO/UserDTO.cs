using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO
{
    public interface UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate {  get; set; }
        public double Wallet {  get; set; }
        public DateTime RegisterDate {  get; set; }
        public int Role {  get; set; }
        public int Status {  get; set; }
    }
}

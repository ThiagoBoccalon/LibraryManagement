using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string username, string email, string password, string address, string postcode,  RoleEnum role)
        {
            UserName = username;
            Email = email;
            Password = password;
            Address = address;
            PostCode = postcode;
            Role = role;
        }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public string PostCode { get; private set; }
        public RoleEnum Role { get; private set; }
    }
}

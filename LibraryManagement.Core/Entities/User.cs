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
        public User(string username, string email, RoleEnum role)
        {
            UserName = username;
            Email = email;
            Role = role;
        }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string PostCode { get; private set; }
        public RoleEnum Role { get; private set; }
    }
}

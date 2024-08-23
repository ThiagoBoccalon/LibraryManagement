using LibraryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public static UserViewModel FromEntity(User user)
            => new(user.UserName, user.Email);
    }
}

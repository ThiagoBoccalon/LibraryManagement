﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DTO
{
    public class UserDTO
    {
        public UserDTO(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}

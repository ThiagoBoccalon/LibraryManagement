using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.InputModels
{
    public class CreateUserStaffInputModel
    {
        public string UserName { get; set; }        
        public string Email { get; set; }        
    }
}

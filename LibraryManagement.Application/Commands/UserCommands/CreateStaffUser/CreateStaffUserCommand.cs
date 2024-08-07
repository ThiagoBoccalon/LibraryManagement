using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.CreateStaffUser
{
    public class CreateStaffUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}

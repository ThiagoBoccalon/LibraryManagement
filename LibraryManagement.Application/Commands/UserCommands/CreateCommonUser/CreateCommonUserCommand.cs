using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.CreateCommonUser
{
    public class CreateCommonUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

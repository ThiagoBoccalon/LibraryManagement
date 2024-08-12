using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public UpdateUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}

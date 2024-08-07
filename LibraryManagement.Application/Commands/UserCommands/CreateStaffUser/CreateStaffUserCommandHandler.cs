using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.CreateStaffUser
{
    public class CreateStaffUserCommandHandler : IRequestHandler<CreateStaffUserCommand, int>
    {
        public Task<int> Handle(CreateStaffUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

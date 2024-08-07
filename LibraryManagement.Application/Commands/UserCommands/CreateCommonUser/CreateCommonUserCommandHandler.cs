using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.CreateCommonUser
{
    public class CreateCommonUserCommandHandler : IRequestHandler<CreateCommonUserCommand, int>
    {
        public Task<int> Handle(CreateCommonUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

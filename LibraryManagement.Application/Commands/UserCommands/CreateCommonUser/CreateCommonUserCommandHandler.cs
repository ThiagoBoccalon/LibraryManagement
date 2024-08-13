using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.CreateCommonUser
{
    public class CreateCommonUserCommandHandler : IRequestHandler<CreateCommonUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateCommonUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateCommonUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName, request.Email, request.Password, request.Address, request.PostCode, request.Role);

            await _userRepository.CreateUserAsync(user);            

            return user.Id;
        }
    }
}

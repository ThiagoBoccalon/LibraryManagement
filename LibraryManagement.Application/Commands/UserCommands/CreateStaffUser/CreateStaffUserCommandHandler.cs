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

namespace LibraryManagement.Application.Commands.UserCommands.CreateStaffUser
{
    public class CreateStaffUserCommandHandler : IRequestHandler<CreateStaffUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateStaffUserCommandHandler(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateStaffUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName, request.Address, request.PostCode, request.Email, request.Role);

            await _userRepository.CreateUserAsync(user);

            return user.Id;
        }
    }
}

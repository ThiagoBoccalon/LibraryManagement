using LibraryManagement.Application.InputModels;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Core.Service;
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
    public class CreateStaffUserCommandHandler : IRequestHandler<CreateStaffUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateStaffUserCommandHandler(IUserRepository userRepository, IAuthService authService) 
        { 
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateStaffUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = _authService.ComputeSha256Hash(request.Password);
            var user = request.ToEntity();

            await _userRepository.CreateUserAsync(user);

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}

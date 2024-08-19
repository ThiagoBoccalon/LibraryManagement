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

namespace LibraryManagement.Application.Commands.UserCommands.CreateCommonUser
{
    public class CreateCommonUserCommandHandler : IRequestHandler<CreateCommonUserCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateCommonUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateCommonUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = _authService.ComputeSha256Hash(request.Password);
            var user = request.ToEntity();

            await _userRepository.CreateUserAsync(user);            

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}

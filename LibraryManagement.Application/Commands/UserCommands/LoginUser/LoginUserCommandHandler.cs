using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Core.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginUserViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Using the same algorithm to create the hash
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            // Search the user in the database which match the same email and password in hash format.
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            // If user don't exist, it should return Error Login
            if (user == null)
            {
                return null;
            }

            // If user exists and than, it should generate the token using user date.
            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            var loginuser = new LoginUserViewModel(user.Email, token);

            return ResultViewModel<LoginUserViewModel>.Success(loginuser);
        }
    }
}

using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private IUserRepository _userRepository;


        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.Id);                

            if (user is null) 
            {
                return ResultViewModel<UserViewModel>.Error("User not exist.");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}

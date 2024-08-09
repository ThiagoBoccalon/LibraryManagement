using LibraryManagement.Application.ViewModels;
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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private LibraryManagementDbContext _dbContext;

        public GetUserByIdQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .SingleOrDefaultAsync(b => b.Id == request.Id);

            if (user == null) return null;

            var userDetailsViewModel = new UserViewModel(
                user.UserName,
                user.Email
                );

            return userDetailsViewModel;
        }
    }
}

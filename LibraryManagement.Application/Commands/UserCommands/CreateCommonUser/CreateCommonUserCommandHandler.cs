using LibraryManagement.Core.Entities;
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
        private readonly LibraryManagementDbContext _dbContext;

        public CreateCommonUserCommandHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateCommonUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName, request.Address, request.PostCode, request.Email, request.Role);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}

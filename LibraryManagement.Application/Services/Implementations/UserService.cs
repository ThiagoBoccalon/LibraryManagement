using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Entities;
using LibraryManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly LibraryManagementDbContext _dbContext;

        public UserService(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null) return null;

            return new UserViewModel(user.UserName, user.Email);
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.UserName, inputModel.Email, inputModel.Role);

            _dbContext.Users.Add(user);

            return user.Id;
        }
    }
}

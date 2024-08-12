using LibraryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Repositories
{
    public interface IUserRepository : IBasedRepository
    {
        Task<User> GetUserAsync(int id);
        Task CreateUserAsync(User user);        
    }
}

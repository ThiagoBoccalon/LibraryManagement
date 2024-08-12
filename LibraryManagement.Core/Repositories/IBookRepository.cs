using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Core.DTO;
using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Repositories
{
    public interface IBookRepository : IBasedRepository
    {        
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAllWithParameterAsync(BookStatusEnum bookStatusEnum);
        Task CreateBookAsync(Book book);
    }
}

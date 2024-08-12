using LibraryManagement.Core.DTO;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibraryManagementDbContext _dbContext;

        public BookRepository(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Book>> GetAllWithParameterAsync(BookStatusEnum bookStatusEnum)
        {
            return await _dbContext.Books.Where(p => p.Status == bookStatusEnum).ToListAsync();
        }

        public async Task CreateBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

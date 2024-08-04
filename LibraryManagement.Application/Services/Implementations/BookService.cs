using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly LibraryManagementDbContext _dbContext;
        public BookService(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookViewModel> GetAll(string query)
        {
            var books = _dbContext.Books;

            var booksViewModel = books
                .Select(p => new BookViewModel(p.Id, p.Title, p.Author, p.ISBN, p.PublicationYear))
                .ToList();

            return booksViewModel;
        }

        public BookViewModel GetById(int id)
        {
            /*Method FirstOrDefault will change to SingleOrDefault when 
             application with a database and books have IDs differents.
            */
            var book = _dbContext.Books.FirstOrDefault(p => p.Id == id);

            if (book == null) return null;

            var bookViewModel = new BookViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.PublicationYear
                );

            return bookViewModel;
        }

        public List<BookDetailsViewModel> GetAllWithParameter(string query, BookStatusEnum bookStatusEnum)
        {
            var books = _dbContext.Books;

            var booksViewModel = books
                .Select(b =>
                    new BookDetailsViewModel(
                        b.Id,
                        b.Title,
                        b.Author,
                        b.ISBN,
                        b.PublicationYear,
                        b.Status
                        ))
                .Where(b => b.Status == bookStatusEnum)
                .ToList();

            return booksViewModel;
        }

        public int Create(NewBookInputModel inputModel)
        {
            var book = new Book(
                inputModel.Title,
                inputModel.Author,
                inputModel.ISBN,
                inputModel.PublicationYear
                );

            _dbContext.Books.Add(book);

            return book.Id;
        }

        public void Update(int id, UpdateBookInputModel inputModel)
        {
            var book = _dbContext.Books.FirstOrDefault(p => p.Id == id);

            book.Update(
                inputModel.Title,
                inputModel.Author,
                inputModel.ISBN,
                inputModel.PublicationYear
                );
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(p => p.Id == id);

            book.GettingBookUnvailible();
        }
    }
}

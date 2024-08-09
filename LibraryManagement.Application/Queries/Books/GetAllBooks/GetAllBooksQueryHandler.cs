using LibraryManagement.Application.ViewModels;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Books.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly LibraryManagementDbContext _dbContext;
        public GetAllBooksQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _dbContext.Books;

            var booksViewModel = await books
                .Select(p => new BookViewModel(p.Id, p.Title, p.Author, p.ISBN, p.PublicationYear, p.Status))
                .ToListAsync();

            return booksViewModel;
        }
    }
}

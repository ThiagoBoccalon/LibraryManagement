using LibraryManagement.Application.ViewModels;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Books.GetAllBooksWithParameter
{
    public class GetAllBooksWithParameterQueryHandler : IRequestHandler<GetAllBooksWithParamaterQuery, List<BookViewModel>>
    {
        private readonly LibraryManagementDbContext _dbContext;

        public GetAllBooksWithParameterQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksWithParamaterQuery request, CancellationToken cancellationToken)
        {
            var booksViewModel = _dbContext.Books
                .Select(b => new BookViewModel(
                    b.Id, 
                    b.Title, 
                    b.Author, 
                    b.ISBN, 
                    b.PublicationYear, 
                    b.Status))
                .AsEnumerable()
                .Where(b => b.Status == request.Status)
                .ToList();

            return booksViewModel;
        }
    }
}

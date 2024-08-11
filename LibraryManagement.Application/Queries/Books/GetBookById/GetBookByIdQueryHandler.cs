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

namespace LibraryManagement.Application.Queries.Books.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null) return null;

            var bookDetailsViewModel = new BookViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.PublicationYear,
                book.Status
                );

            return bookDetailsViewModel;
        }
    }
}

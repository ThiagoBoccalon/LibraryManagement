using LibraryManagement.Application.InputModels;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ResultViewModel<Unit>>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            book.Update(
                request.Title, 
                request.Author, 
                request.ISBN, 
                request.PublicationYear, 
                request.Status);

            await _bookRepository.SaveChangesAsync();

            return ResultViewModel<Unit>.Success(Unit.Value);
        }
    }
}

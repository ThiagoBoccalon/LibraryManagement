using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ResultViewModel<Unit>>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
           var book = await _bookRepository.GetByIdAsync(request.Id);
           
           book.GettingBookDeleted(); 
                       
           await _bookRepository.SaveChangesAsync();

            return ResultViewModel<Unit>.Success(Unit.Value);
        }
    }
}

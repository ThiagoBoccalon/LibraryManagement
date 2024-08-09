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
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly LibraryManagementDbContext _dbContext;

        public UpdateBookCommandHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == request.Id);

            book.Update(
                request.Title, 
                request.Author, 
                request.ISBN, 
                request.PublicationYear, 
                request.Status);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

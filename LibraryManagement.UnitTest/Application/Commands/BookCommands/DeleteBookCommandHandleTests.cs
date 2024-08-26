using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using LibraryManagement.Application.Commands.BookCommands.DeleteBook;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Application.Commands.BookCommands
{
    public class DeleteBookCommandHandleTests
    {
        //[Fact]
        public async Task DeleteDataIsOk_Executed_DeleteBook()
        {
            var bookRepository = new Mock<IBookRepository>();
            var book = new Mock<Book>();
            
            var deleteBookCommand = new DeleteBookCommand(1);
                    
            var deleteBookCommandHandler = new DeleteBookCommandHandler(bookRepository.Object);

            var result = await deleteBookCommandHandler.Handle(deleteBookCommand, new CancellationToken());
            
            Assert.True(result.IsSuccess);
            
            bookRepository.Verify(bR => bR.GetByIdAsync(1), Times.Once);
        }        
    }
}

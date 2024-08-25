using LibraryManagement.Application.Commands.BookCommands.CreateBook;
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
    public class CreateBookCommandHandleTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnBookId()
        {
            var bookRepository = new Mock<IBookRepository>();
            var createBookCommand = new CreateBookCommand
            {
                Title = "Title",
                Author = "Author",
                ISBN = "123-456-789-0",
                PublicationYear = 1990
            };

            var createBookCommandHandler = new CreateBookCommandHandler(bookRepository.Object);

            var id = await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

            Assert.NotNull(id);
            Assert.True(id.Data >= 0);
            bookRepository.Verify(bR => bR.CreateBookAsync(It.IsAny<Book>()), Times.Once);
        }
    }
}

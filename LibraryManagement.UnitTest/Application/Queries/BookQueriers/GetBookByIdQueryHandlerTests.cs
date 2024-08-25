using LibraryManagement.Application.Queries.Books.GetBookById;
using LibraryManagement.Application.Queries.Loans.GetLoanById;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Application.Queries.BookQueriers
{
    public class GetBookByIdQueryHandlerTests
    {
        [Fact]
        public async void OneBookExist_Executed_ReturnUserViewModel()
        {
            // Arrange
            var book = new Book("Title Test", "Author Test", "123-456-789-0", 1900);

            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(br => br.GetByIdAsync(book.Id).Result).Returns(book);

            var getBookQuery = new GetBookByIdQuery(book.Id);
            var getBookQueryHandler = new GetBookByIdQueryHandler(bookRepositoryMock.Object);

            //Act
            var bookViewModel = await getBookQueryHandler.Handle(getBookQuery, new CancellationToken());
            
            //Assert
            Assert.NotNull(bookViewModel);
            Assert.Equal(book.Status, bookViewModel.Data.Status);
            Assert.Equal(book.Title, bookViewModel.Data.Title);

            bookRepositoryMock.Verify(br => br.GetByIdAsync(book.Id), Times.Once());
        }
    }
}

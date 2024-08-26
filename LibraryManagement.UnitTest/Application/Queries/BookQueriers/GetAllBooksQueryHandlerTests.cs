using LibraryManagement.Application.Queries.Books.GetAllBooks;
using LibraryManagement.Application.Queries.Loans.GetAllLoans;
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
    public class GetAllBooksQueryHandlerTests
    {
        public async void BooksExist_Executed_ReturnUserViewModel()
        {
            // Arrange
            var books = new List<Book>()
            {
               new Book("Title Test 1", "Author Test 1", "123-456-789-0", 1900),
               new Book("Title Test 2", "Author Test 2", "123-456-789-0", 2000)
            };

            var booksRepositoryMock = new Mock<IBookRepository>();
            booksRepositoryMock.Setup(lr => lr.GetAllAsync().Result).Returns(books);

            var getAllBookQuery = new GetAllBooksQuery("");
            var getBookQueryHandler = new GetAllBooksQueryHandler(booksRepositoryMock.Object);

            //Act
            var booksViewModel = await getBookQueryHandler.Handle(getAllBookQuery, new CancellationToken());


            //Assert
            Assert.NotNull(booksViewModel);
            Assert.Equal(books.Count(), booksViewModel.Data.Count());
            Assert.Equal(books[0].Title, booksViewModel.Data[0].Title);
            Assert.Equal(books[1].Title, booksViewModel.Data[1].Title);

            Assert.True(booksViewModel.IsSuccess);
            Assert.Equal(string.Empty, booksViewModel.Message);
        }
    }
}

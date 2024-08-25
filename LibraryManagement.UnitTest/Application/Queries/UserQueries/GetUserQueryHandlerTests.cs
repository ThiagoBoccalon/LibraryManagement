using LibraryManagement.Application.Queries.Books.GetAllBooks;
using LibraryManagement.Application.Queries.Users.GetUserById;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Application.Queries.UserQueries
{
    public class GetUserQueryHandlerTests
    {
        [Fact]
        public async void OneUserExist_Executed_ReturnUserViewModel()
        {
            // Arrange
            var user = new User(
                "James B",
                "james.b@mail.com",
                "202#Abcv",
                "100 New England",
                "SW81XW",
                RoleEnum.CommonUserLibrary
                );

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(ur => ur.GetUserAsync(user.Id).Result).Returns(user);

            var getUserQuery = new GetUserByIdQuery(user.Id);
            var getUserQueryHandler = new GetUserByIdQueryHandler(userRepositoryMock.Object);

            //Act
            var userViewModel = await getUserQueryHandler.Handle(getUserQuery, new CancellationToken());

            //Assert
            Assert.NotNull(userViewModel);
            Assert.Equal(userViewModel.Data.Email, user.Email);
            
            userRepositoryMock.Verify(ur => ur.GetUserAsync(user.Id), Times.Once());
        }
    }
}

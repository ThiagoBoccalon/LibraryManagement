using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using LibraryManagement.Application.Commands.UserCommands.CreateCommonUser;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Core.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Application.Commands.UserCommands
{
    public class CreateUserCommandHandleTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnBookId()
        {
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();

            var createCommonUserCommand = new CreateCommonUserCommand
            {
                UserName = "Test name",
                Email = "test.2024@mail.com",
                Password = "2020@Dpam",
                Address = "Test address",
                PostCode = "123 45"                
            };

            var createCommonUserCommandHandler = new CreateCommonUserCommandHandler(userRepository.Object,authService.Object);

            var id = await createCommonUserCommandHandler.Handle(createCommonUserCommand, new CancellationToken());

            Assert.NotNull(id);
            Assert.True(id.Data >= 0);
            userRepository.Verify(uR => uR.CreateUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}

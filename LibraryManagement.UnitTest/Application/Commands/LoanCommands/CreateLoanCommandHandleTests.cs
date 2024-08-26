using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using LibraryManagement.Application.Commands.LoanCommands.CreateLoan;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Application.Commands.LoanCommands
{
    public class CreateLoanCommandHandleTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnLoanId()
        {
            var loanRepository = new Mock<ILoanRepository>();
            var createLoanCommand = new CreateLoanCommand
            {
                IdBook = 1,
                IdUser = 1
            };

            var createLoanCommandHandler = new CreateLoanCommandHandler(loanRepository.Object);

            var id = await createLoanCommandHandler.Handle(createLoanCommand, new CancellationToken());

            Assert.NotNull(id);
            Assert.True(id.Data >= 0);
            loanRepository.Verify(bR => bR.CreateLoanAsync(It.IsAny<Loan>()), Times.Once);
        }
    }
}

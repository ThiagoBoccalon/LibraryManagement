using LibraryManagement.Application.Queries.Loans.GetLoanById;
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

namespace LibraryManagement.UnitTest.Application.Queries.LoanQueries
{
    public class GetLoansByIdQuerryHandlerTests
    {
        [Fact]
        public async void OneLoanExist_Executed_ReturnUserViewModel()
        {
            // Arrange
            var loan = new Loan(1,1);

            var loanRepositoryMock = new Mock<ILoanRepository>();
            loanRepositoryMock.Setup(lr => lr.GetByIdAsync(loan.Id).Result).Returns(loan);

            var getLoanQuery = new GetLoanByIdQuery(loan.Id);
            var getLoanQueryHandler = new GetLoanByIdQueryHandler(loanRepositoryMock.Object);

            var startingLoan = DateTime.Now.Date.ToString("dd/MM");
            var endingLoan = DateTime.Now.Date.AddDays(14).ToString("dd/MM");

            //Act
            var loanViewModel = await getLoanQueryHandler.Handle(getLoanQuery, new CancellationToken());
            var loanStarted = loanViewModel.Data.LoanStartedAt.ToString("dd/MM");
            var loanFinished = loanViewModel.Data.LoanEndAt.ToString("dd/MM");
            
            
            //Assert
            Assert.NotNull(loanViewModel);
            Assert.Equal(startingLoan, loanStarted);
            Assert.Equal(endingLoan, loanFinished);

            loanRepositoryMock.Verify(ul => ul.GetByIdAsync(loan.Id), Times.Once());
        }
    }
}

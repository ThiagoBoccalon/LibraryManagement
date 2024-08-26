using LibraryManagement.Application.Queries.Loans.GetAllLoans;
using LibraryManagement.Application.Queries.Loans.GetLoanById;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Application.Queries.LoanQueries
{
    public class GetAllLoansQuerryHandlerTests
    {
        [Fact]
        public async void LoansExist_Executed_ReturnUserViewModel()
        {
            // Arrange
            var loans = new List<Loan>()
            {
                new Loan(1,2),
                new Loan(2,3),
                new Loan(3,4),
            };

            var loanRepositoryMock = new Mock<ILoanRepository>();
            loanRepositoryMock.Setup(lr => lr.GetAllAsync().Result).Returns(loans);

            var getAllLoanQuery = new GetAllLoansQuery("");
            var getLoanQueryHandler = new GetAllLoansQueryHandler(loanRepositoryMock.Object);

            //Act
            var loansViewModel = await getLoanQueryHandler.Handle(getAllLoanQuery, new CancellationToken());
            

            //Assert
            Assert.NotNull(loansViewModel);
            Assert.Equal(loans.Count(), loansViewModel.Data.Count());
            Assert.Equal(loans[0].IdUser, loansViewModel.Data[0].IdUser);
            Assert.Equal(loans[0].IdBook, loansViewModel.Data[0].IdBook);

            Assert.True(loansViewModel.IsSuccess);
            Assert.Equal(string.Empty, loansViewModel.Message);
        }
    }
}

using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Core
{
    public class LoanTests
    {
        private const int daysForReturningBookIs = 14;
        private DateTime mockingDayWithDelayForTesting = DateTime.Now.AddDays(-5);

        [Fact]
        public void TestIfLoanIsCreated()
        {
            var loan = GetOneLoan();

            Assert.NotNull(loan);
            var todayIs = DateTime.Now.Day;
            Assert.Equal(todayIs, loan.LoanAtStarted.Day);

            var bookReturnsMustBe = DateTime.Now.Date.AddDays(daysForReturningBookIs);
        }

        [Fact]
        public void TestIfLoanIsUpdated()
        {
            var loan = GetOneLoan();
            loan.Update(1, 2);

            var idUser = 1;
            var idBook = 2;

            Assert.Equal(idUser, loan.IdUser);
            Assert.Equal(idBook, loan.IdBook);
        }

        [Fact]
        public void TestLoanRenewalWhenItHasSuccessed()
        {
            var loan = GetOneLoan();            
            var messageToCompareIs = $"Your Loan has been renewed for {DateTime.Now.AddDays(14).ToString("dd/MM")}";

            var loanMessage = loan.Renewal(loan.LoanForReturning);            
            Assert.Equal(messageToCompareIs, loanMessage);
        }

        [Fact]
        public void TestLoanRenewalWhenItHasFailed()
        {
            var loan = GetOneLoan();            
            var message = "You won't be able to renew an item that has had a penalty for delay.";

            var loanMessage = loan.Renewal(mockingDayWithDelayForTesting);
            Assert.Equal(message, loanMessage);
        }

        [Fact]
        public void TestLoanReturnWhenItHasPenaltyToPay()
        {
            var loan = GetOneLoan();
            
            int daysOfDelay = 5;
            var mockingCurrentDay = DateTime.Now.AddDays(daysForReturningBookIs + daysOfDelay);
            var charge = 0.25 * daysOfDelay;

            var messageFromMethodIs = loan.Return(mockingCurrentDay);

            var message = $"The has returned with delay, so you will be able to pay a penalty of £{charge}.";

            Assert.Equal(LoanStatusEnum.DeliveredWithCharge, loan.Status);
            Assert.Equal(message, messageFromMethodIs);


            Assert.True(true);
        }

        [Fact]
        public void TestLoanReturnWhenItHasDone()
        {
            var loan = GetOneLoan();
        }

        [Fact]
        public void TestLoanHasDeleted()
        {
            var loan = GetOneLoan();
            var statusMocking = LoanStatusEnum.Activity;

            var messageLoanDeletedIs = loan.Delete(statusMocking);

            var message = $"Loan is deleted!";
        }

        private Loan GetOneLoan()
        {
            return new Loan(1, 1);
        }
    }
}

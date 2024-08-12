using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Repositories
{
    public interface ILoanRepository : IBasedRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task<Loan> GetByIdAsync(int id);
        Task<List<Loan>> GetLoansWithParameterAsync(LoanStatusEnum status);
        Task CreateLoanAsync(Loan loan);
    }
}

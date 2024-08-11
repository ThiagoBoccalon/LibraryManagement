using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private LibraryManagementDbContext _dbContext;

        public LoanRepository(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateLoanAsync(Loan loan)
        {
            await _dbContext.Loans.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _dbContext.Loans.ToListAsync();
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _dbContext.Loans.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Loan>> GetLoansWithParameterAsync(LoanStatusEnum status)
        {
            return await _dbContext.Loans.Where(p => p.Status == status).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

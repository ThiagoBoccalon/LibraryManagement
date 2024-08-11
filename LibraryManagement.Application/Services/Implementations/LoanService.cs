﻿using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly LibraryManagementDbContext _dbContext;

        public LoanService(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewLoanInputModel inputModel)
        {

            var loan = new Loan(inputModel.IdUser, inputModel.IdBook);
            _dbContext.Loans.Add(loan);
            _dbContext.SaveChanges();

            return loan.Id;
        }

        public string Renewal(int id)
        {
            var loan = _dbContext.Loans.SingleOrDefault(l => l.Id == id);

            if (loan == null) return "NotFound";

            var result = loan.Renewal();
            _dbContext.SaveChanges();

            return result;

        }

        public string Return(int id)
        {
            var loan = _dbContext.Loans.FirstOrDefault(l => l.Id == id);

            if (loan == null) return "NotFound";

            var result = loan.Return(DateTime.Now);

            _dbContext.SaveChanges();

            return result;
        }

        public void Update(int id, UpdateLoanInputModel inputModel)
        {
            var loan = _dbContext.Loans.FirstOrDefault(l => l.Id == id);

            loan.Update(inputModel.IdUser, inputModel.IdBook);

            _dbContext.SaveChanges();
        }

        public string Delete(int id)
        {
            var loan = _dbContext.Loans.FirstOrDefault(l => l.Id == id);
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == loan.IdBook);

            book.GettingBookAvaililable();

            var result = loan.Delete();
            _dbContext.SaveChanges();

            return result;
        }
    }
}

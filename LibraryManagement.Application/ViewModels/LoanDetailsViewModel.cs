using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.ViewModels
{
    public class LoanDetailsViewModel : LoanViewModel
    {
        public LoanDetailsViewModel(int id, int idUser, int idBook, DateTime loanStartedAt, DateTime loanEndAt, LoanStatusEnum status) : base(id, idUser, idBook, loanStartedAt, loanEndAt)
        {
            Status = status;
        }

        public LoanStatusEnum Status { get; private set; }
    }
}

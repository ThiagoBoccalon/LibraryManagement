using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DTO
{
    public class LoanDetailsDTO : LoanDTO
    {
        public LoanDetailsDTO(int id, int idUser, int idBook, DateTime loanStartedAt, DateTime loanEndAt, LoanStatusEnum status) : base(id, idUser, idBook, loanStartedAt, loanEndAt)
        {
            Status = status;
        }

        public LoanStatusEnum Status { get; private set; }
    }
}

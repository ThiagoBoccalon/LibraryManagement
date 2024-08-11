using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DTO
{
    public class LoanDTO
    {
        public LoanDTO(int id, int idUser, int idBook, DateTime loanStartedAt, DateTime loanEndAt)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanStartedAt = loanStartedAt;
            LoanEndAt = loanEndAt;
        }
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public DateTime LoanStartedAt { get; private set; }
        public DateTime LoanEndAt { get; private set; }
    }
}

using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook, int idLibrary)
        {
            IdUser = idUser;
            IdBook = idBook;

            LoanAtStarted = DateTime.Now.Date;
            LoanForReturning = DateTime.Now.Date.AddDays(14);
        }
        public int IdUser { get; private set; }
        public User? User { get; private set; }
        public int IdBook { get; private set; }
        public Book? Book { get; private set; }
        public LoanStatusEnum Status { get; private set; }
        public DateTime LoanAtStarted { get; private set; }
        public DateTime LoanForReturning { get; private set; }
    }
}

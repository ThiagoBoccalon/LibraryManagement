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
        protected Loan() { }
        public Loan(int idUser, int idBook)
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

        public void Update(int idUser, int idBook)
        {            
            IdUser = idUser;
            IdBook = idBook;            
        }

        public string Renewal()
        {
            if (DateTime.Now <= LoanForReturning)
            {
                LoanForReturning = DateTime.Now.Date.AddDays(7);
                var newLoanForReturning = LoanForReturning.ToString("MM-dd");
                return $"Your Loan has been renewed for {newLoanForReturning}";
            }

            return "You won't be able to renew an item that has had a penalty for delay.";
        }


        /*
         * Methods bellow are to do when Library class
         * Charge will be doing in User class
         */
        public string Return(DateTime dateOnly)
        {
            if (dateOnly > LoanForReturning)
            {
                var charge = (decimal)((dateOnly.Day - LoanForReturning.Day) * 0.25m);
                Status = LoanStatusEnum.DeliveredWithCharge;

                return $"The has returned with delay, so you will be able to pay a penalty of £{charge}.";
            }

            Status = LoanStatusEnum.Delivered;
            return "We appreciate you have returned books on right time";
        }

        public string Delete()
        {
            if (Status != LoanStatusEnum.DeliveredWithCharge)
            {
                Status = LoanStatusEnum.Deleted;

                return $"Loan is deleted!";
            }

            return $"Loan can't be to delete!";
        }
    }
}

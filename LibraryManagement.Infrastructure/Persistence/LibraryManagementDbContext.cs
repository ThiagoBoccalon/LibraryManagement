using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Persistence
{
    public class LibraryManagementDbContext : DbContext
    {
        public LibraryManagementDbContext()
        {
            Books = new List<Book>()
            {
                new Book("1984", "George Onwell", "asd72", 1949),
                new Book("1984", "George Onwell", "asd72", 1949),
                new Book("Pride and Prejudice", "Jane Austen", "sdas-2", 1813),
                new Book("The Lion, the Witch and the Wardrobe", "C.S Lewis", "asxfd", 1950)
            };

            Users = new List<User>()
            {
                new User("Olivia", "olivia@dotnet.com", Core.Enums.RoleEnum.CommonUserLibrary),
                new User("James", "james@dotnet.com", Core.Enums.RoleEnum.StaffUserLibrary),
                new User("William", "william@dotnet.com", Core.Enums.RoleEnum.CommonUserLibrary)
            };

            Loans = new List<Loan>()
            {
                new Loan(1,  0),
                new Loan(2, 0)
            };
        }
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public List<Loan> Loans { get; set; }
    }
}

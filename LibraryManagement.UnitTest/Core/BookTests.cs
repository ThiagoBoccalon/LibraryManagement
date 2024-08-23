using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Core
{
    public class BookTests
    {
        [Fact]
        public void TestIfBookIsCreated()
        {
            var book = GetOneBook();

            Assert.NotNull(book.Title);
            Assert.NotNull(book.Author);
            Assert.NotNull(book.ISBN);
            Assert.True(book.PublicationYear > 0);

            Assert.Equal(BookStatusEnum.Available, book.Status);
        }

        [Fact]
        public void TestIfGettingBookAvaililableIsWorking()
        {
            var book = GetOneBook();
            book.GettingBookUnvailible();
            book.GettingBookAvaililable();

            Assert.Equal(BookStatusEnum.Available, book.Status);
        }

        [Fact]
        public void TestIfGettingBookUnvailibleIsWorking()
        {
            var book = GetOneBook();
            book.GettingBookUnvailible();

            Assert.Equal(BookStatusEnum.Unvailable, book.Status);
        }

        [Fact]
        public void TestIfGettingBookDeletedIsWorking()
        {
            var book = GetOneBook();
            book.GettingBookDeleted();

            Assert.Equal(BookStatusEnum.Deleted, book.Status);
        }

        private Book GetOneBook()
        {
            return new Book("1984", "george Onwell", "123-456-789-9", 1949);
        }
    }
}

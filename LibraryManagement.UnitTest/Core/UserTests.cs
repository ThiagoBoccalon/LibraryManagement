using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UnitTest.Core
{
    public class UserTests
    {
        [Fact]
        public void TestIfUserIsCreated()
        {
            var userCommon = GetOneUser();

            Assert.NotNull(userCommon.UserName);
            Assert.NotNull(userCommon.Email);
            Assert.NotNull(userCommon.Password);
            Assert.NotNull(userCommon.Address);
            Assert.NotNull(userCommon.PostCode);

            Assert.Equal(RoleEnum.CommonUserLibrary, userCommon.Role);
        }

        private User GetOneUser()
        {
            return new User("James B.", "james@mail.com", "123@Abcd", "100 Acton Lane", "W4 5DL", RoleEnum.CommonUserLibrary);
        }
    }
}

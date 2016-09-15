using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using epicodus_dotnet_rpg.Models;
using Xunit;

namespace RPG.Tests
{
    public class ApplicationUserTest
    {
        [Fact]
        public void GetUserNameTest()
        {
            var newUser = new ApplicationUser { UserName = "CharlesEwel" };

            var newUserName = newUser.UserName;

            Assert.Equal("CharlesEwel", newUserName);
        }
    }
}

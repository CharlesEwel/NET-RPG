using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using epicodus_dotnet_rpg.Controllers;
using epicodus_dotnet_rpg.Models;
using Xunit;
using Microsoft.AspNetCore.Identity;

namespace RPG.Tests.ControllerTests
{
    public class AccountControllerTest
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelList_UserList_Test()
        {
            //Arrange
            AccountController controller = new AccountController(_userManager, _signInManager, _db);
            IActionResult actionResult = controller.UserList();
            ViewResult userListView = controller.UserList() as ViewResult;

            //Act
            var result = userListView.ViewData.Model;

            //Assert
            Assert.IsType<List<ApplicationUser>>(result);
        }
    }
}

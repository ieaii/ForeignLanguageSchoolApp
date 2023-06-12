using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.IntegrationTests
{
    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        public void AddUser_AddUser_ReturnTrue()
        {
            Users users = new Users()
            {
                UserLogin = "d",
                UserPassword = "e",
                UserName = "s",
                UserPatronymic = "s",
                UserSurname = "s",
                UserTypeId = 1
            };
            UsersController usersController = new UsersController();
            Assert.IsTrue(usersController.AddUser(users));
        }
    }
}

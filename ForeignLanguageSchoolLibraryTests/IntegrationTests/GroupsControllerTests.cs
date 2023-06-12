using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.IntegrationTests
{
    [TestClass]
    public class GroupsControllerTests
    {
        [TestMethod]
        public void AddGroup_AddGroup_ReturnTrue()
        {
            Groups groups = new Groups()
            {
                GroupName = "as"
            };
            GroupsController groupsController = new GroupsController();
            Assert.IsTrue(groupsController.AddGroup(groups));
        }
    }
}

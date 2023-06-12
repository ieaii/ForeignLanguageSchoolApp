using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.IntegrationTests
{
    [TestClass]
    public class ClassesControllerTests
    {
        [TestMethod]
        public void AddClasses_AddClass_ReturnTrue()
        {
            Classes classes = new Classes()
            {
                ClassTime = new TimeSpan(),
                ClassDate = DateTime.Now,
                IdGroup = 1
            };
            ClassesController classesController = new ClassesController();
            Assert.IsTrue(classesController.AddClasses(classes));
        }
    }
}

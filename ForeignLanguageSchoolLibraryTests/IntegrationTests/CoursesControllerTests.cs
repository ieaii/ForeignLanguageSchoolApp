using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.IntegrationTests
{
    [TestClass]
    public class CoursesControllerTests
    {
        [TestMethod]
        public void AddCourse_AddCourse_ReturnTrue()
        {
            Courses courses = new Courses()
            {
                CourseName = "Новый курс",
                CourseDescription = "Описание"
            };
            CoursesController coursesController = new CoursesController();
            Assert.IsTrue(coursesController.AddCourse(courses));
        }
    }
}

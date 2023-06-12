using ForeignLanguageSchoolLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.ModuleTests
{
    [TestClass]
    public class CoursesInfoCheckTests
    {
        CoursesInfoCheck coursesInfoCheck = new CoursesInfoCheck();
        [TestMethod]
        public void CheckNameInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(coursesInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(coursesInfoCheck.CheckNameInfo(entry));
        }

        
        [TestMethod]
        public void CheckNameInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "@!#$";
            Assert.IsFalse(coursesInfoCheck.CheckNameInfo(entry));
        }

        

        [TestMethod]
        public void CheckNameInfo_LongEntry_ReturnFalse()
        {
            string entry = "ааааааааааааааааааааааааааааааааааааааааааааааааааввв";
            Assert.IsFalse(coursesInfoCheck.CheckNameInfo(entry));
        }


        [TestMethod]
        public void CheckNameInfo_OnlyLowerEntry_ReturnTrue()
        {
            string entry = "программирование";
            Assert.IsTrue(coursesInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerEntry_ReturnTrue()
        {
            string entry = "Программирование";
            Assert.IsTrue(coursesInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerNumberEntry_ReturnTrue()
        {
            string entry = "Программирование1";
            Assert.IsTrue(coursesInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerNumberSpaceEntry_ReturnTrue()
        {
            string entry = "Программирование 1";
            Assert.IsTrue(coursesInfoCheck.CheckNameInfo(entry));
        }




        ///CheckDescriptionInfoInfo

        [TestMethod]
        public void CheckDescriptionInfoInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfoInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }


        [TestMethod]
        public void CheckDescriptionInfoInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "@!#$";
            Assert.IsFalse(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }


        [TestMethod]
        public void CheckDescriptionInfoInfo_OnlyLowerEntry_ReturnTrue()
        {
            string entry = "программирование";
            Assert.IsTrue(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfoInfo_UperLowerEntry_ReturnTrue()
        {
            string entry = "Программирование";
            Assert.IsTrue(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfoInfo_UperLowerNumberEntry_ReturnTrue()
        {
            string entry = "Программирование1";
            Assert.IsTrue(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfoInfo_UperLowerNumberSpaceEntry_ReturnTrue()
        {
            string entry = "Программирование 1";
            Assert.IsTrue(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfoInfo_UperLowerNumberSpaceSynbolsEntry_ReturnTrue()
        {
            string entry = "Программирование, - 1.";
            Assert.IsTrue(coursesInfoCheck.CheckDescriptionInfoInfo(entry));
        }
    }
}

using ForeignLanguageSchoolLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests
{
    [TestClass]
    public class ClassInfoCheckTests
    {
        ClassInfoCheck classInfoCheck = new ClassInfoCheck();
        [TestMethod]
        public void CheckTimeInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(classInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(classInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "дчрчлд";
            Assert.IsFalse(classInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "##$";
            Assert.IsFalse(classInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_WrongMinutesEntry_ReturnFalse()
        {
            string entry = "11:66";
            Assert.IsFalse(classInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_WrongHoursEntry_ReturnFalse()
        {
            string entry = "26:56";
            Assert.IsFalse(classInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_RightEntry_ReturnTrue()
        {
            string entry = "23:56";
            Assert.IsTrue(classInfoCheck.CheckTimeInfo(entry));
        }
    }
}

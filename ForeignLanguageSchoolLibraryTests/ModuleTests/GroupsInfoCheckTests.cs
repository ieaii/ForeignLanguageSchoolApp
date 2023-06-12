using ForeignLanguageSchoolLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.ModuleTests
{
    [TestClass]
    public class GroupsInfoCheckTests
    {
        GroupInfoCheck groupInfoCheck = new GroupInfoCheck();
        [TestMethod]
        public void CheckNameInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(groupInfoCheck.CheckNameInfo(entry));
        }


        [TestMethod]
        public void CheckNameInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "@!#$";
            Assert.IsFalse(groupInfoCheck.CheckNameInfo(entry));
        }



        [TestMethod]
        public void CheckNameInfo_LongEntry_ReturnFalse()
        {
            string entry = "ааааааааааааааааааааааааааааааааааааааааааааааааааввв";
            Assert.IsFalse(groupInfoCheck.CheckNameInfo(entry));
        }


        [TestMethod]
        public void CheckNameInfo_OnlyLowerEntry_ReturnTrue()
        {
            string entry = "программирование";
            Assert.IsTrue(groupInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerEntry_ReturnTrue()
        {
            string entry = "Программирование";
            Assert.IsTrue(groupInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerNumberEntry_ReturnTrue()
        {
            string entry = "Программирование1";
            Assert.IsTrue(groupInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerNumberSpaceEntry_ReturnTrue()
        {
            string entry = "Программирование 1";
            Assert.IsTrue(groupInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerNumberSpaceSymbolsEntry_ReturnTrue()
        {
            string entry = "Программирование - 1";
            Assert.IsTrue(groupInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_UperLowerNumberSpaceSymbolsLatinEntry_ReturnTrue()
        {
            string entry = "Прог progr  - 1";
            Assert.IsTrue(groupInfoCheck.CheckNameInfo(entry));
        }

    }
}

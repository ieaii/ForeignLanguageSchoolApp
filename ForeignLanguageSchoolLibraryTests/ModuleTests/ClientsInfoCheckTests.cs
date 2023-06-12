using ForeignLanguageSchoolLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.ModuleTests
{
    [TestClass]
    public class ClientsInfoCheckTests
    {
        ClientsInfoCheck clientsInfoCheck = new ClientsInfoCheck();
        [TestMethod]
        public void CheckFIOInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(clientsInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(clientsInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_NumbersEntry_ReturnFalse()
        {
            string entry = "8237489";
            Assert.IsFalse(clientsInfoCheck.CheckFIOInfo(entry));
        }
        [TestMethod]
        public void CheckFIOInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "@!#$";
            Assert.IsFalse(clientsInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_WrongEntry_ReturnFalse()
        {
            string entry = "алеша";
            Assert.IsFalse(clientsInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_LongEntry_ReturnFalse()
        {
            string entry = "алешаалешаалешаалешаалешаалешаалешаалешаалешаалешаалеша";
            Assert.IsFalse(clientsInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_RightEntry_ReturnTrue()
        {
            string entry = "Алеша";
            Assert.IsTrue(clientsInfoCheck.CheckFIOInfo(entry));
        }


        //phoneInfo


        [TestMethod]
        public void CheckPhoneInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(clientsInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(clientsInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "длшфывол";
            Assert.IsFalse(clientsInfoCheck.CheckPhoneInfo(entry));
        }

        
        [TestMethod]
        public void CheckPhoneInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "@!#$";
            Assert.IsFalse(clientsInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_WrongEightEntry_ReturnFalse()
        {
            string entry = "80567465734";
            Assert.IsFalse(clientsInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_WrongPlusEntry_ReturnFalse()
        {
            string entry = "+70567465734";
            Assert.IsFalse(clientsInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_RightEntry_ReturnTrue()
        {
            string entry = "70567465734";
            Assert.IsTrue(clientsInfoCheck.CheckPhoneInfo(entry));
        }


        //CheckLoginInfo

        [TestMethod]
        public void CheckLoginInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(clientsInfoCheck.CheckLoginInfo(entry));
        }

        [TestMethod]
        public void CheckLoginInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "лфвлдо";
            Assert.IsFalse(clientsInfoCheck.CheckLoginInfo(entry));
        }

      
        [TestMethod]
        public void CheckLoginInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "@!#$";
            Assert.IsFalse(clientsInfoCheck.CheckLoginInfo(entry));
        }

        [TestMethod]
        public void CheckLoginInfo_ShortEntry_ReturnFalse()
        {
            string entry = "ll";
            Assert.IsFalse(clientsInfoCheck.CheckLoginInfo(entry));
        }

        [TestMethod]
        public void CheckLoginInfo_LongEntry_ReturnFalse()
        {
            string entry = "llaljsdkljalsdjklashd";
            Assert.IsFalse(clientsInfoCheck.CheckLoginInfo(entry));
        }

        

        [TestMethod]
        public void CheckLoginInfo_RightLowerEntry_ReturnTrue()
        {
            string entry = "alesha";
            Assert.IsTrue(clientsInfoCheck.CheckLoginInfo(entry));
        }

        [TestMethod]
        public void CheckLoginInfo_RightLowerUperEntry_ReturnTrue()
        {
            string entry = "Alesha";
            Assert.IsTrue(clientsInfoCheck.CheckLoginInfo(entry));
        }

        [TestMethod]
        public void CheckLoginInfo_RightLowerUperNumberEntry_ReturnTrue()
        {
            string entry = "Alesha2";
            Assert.IsTrue(clientsInfoCheck.CheckLoginInfo(entry));
        }


        ///CheckPasswordInfo

        [TestMethod]
        public void CheckPasswordInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(clientsInfoCheck.CheckPasswordInfo(entry));
        }

        [TestMethod]
        public void CheckPasswordInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "лфвлдо";
            Assert.IsFalse(clientsInfoCheck.CheckPasswordInfo(entry));
        }


       

        [TestMethod]
        public void CheckPasswordInfo_ShortEntry_ReturnFalse()
        {
            string entry = "ll";
            Assert.IsFalse(clientsInfoCheck.CheckPasswordInfo(entry));
        }

        [TestMethod]
        public void CheckPasswordInfo_LongEntry_ReturnFalse()
        {
            string entry = "llaljsdkljalsdjklashdyuyuiyalsdlasdjkhajkwhduaukh";
            Assert.IsFalse(clientsInfoCheck.CheckPasswordInfo(entry));
        }

        [TestMethod]
        public void CheckPasswordInfo_OnlyLowerEntry_ReturnFalse()
        {
            string entry = "aleshaalesh";
            Assert.IsFalse(clientsInfoCheck.CheckPasswordInfo(entry));
        }

        [TestMethod]
        public void CheckPasswordInfo_LowerUperEntry_ReturnFalse()
        {
            string entry = "aleshaaleSH";
            Assert.IsFalse(clientsInfoCheck.CheckPasswordInfo(entry));
        }

        [TestMethod]
        public void CheckPasswordInfo_LowerUperNumberEntry_ReturnFalse()
        {
            string entry = "aleshaaleSH23";
            Assert.IsFalse(clientsInfoCheck.CheckPasswordInfo(entry));
        }

        [TestMethod]
        public void CheckPasswordInfo_RightEntry_ReturnTrue()
        {
            string entry = "aleshaA08$";
            Assert.IsTrue(clientsInfoCheck.CheckPasswordInfo(entry));
        }

        ///CheckEmailInfo

        [TestMethod]
        public void CheckEmailInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(clientsInfoCheck.CheckEmailInfo(entry));
        }

        [TestMethod]
        public void CheckEmailInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "лфвлдо";
            Assert.IsFalse(clientsInfoCheck.CheckEmailInfo(entry));
        }


        

       
        [TestMethod]
        public void CheckEmailInfo_OnlyLowerEntry_ReturnFalse()
        {
            string entry = "aleshaalesh";
            Assert.IsFalse(clientsInfoCheck.CheckEmailInfo(entry));
        }

        [TestMethod]
        public void CheckEmailInfo_WithoutEndEntry_ReturnFalse()
        {
            string entry = "aleshaaleSH@gmail";
            Assert.IsFalse(clientsInfoCheck.CheckEmailInfo(entry));
        }

       

        [TestMethod]
        public void CheckEmailInfo_RightEntry_ReturnTrue()
        {
            string entry = "alesha@mail.ru";
            Assert.IsTrue(clientsInfoCheck.CheckEmailInfo(entry));
        }
    }
}

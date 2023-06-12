using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.IntegrationTests
{
    [TestClass]
    public class MessagesControllerTests
    {
        [TestMethod]
        public void AddMessages_AddMessage_ReturnTrue()
        {
            Messages messages = new Messages()
            {
                MessageMessage = "d",
                UserId = 1,
                ClientId = 1
            };
            MessagesController messagesController = new MessagesController();
            Assert.IsTrue(messagesController.AddNewMessage(messages));
        }
    }
}

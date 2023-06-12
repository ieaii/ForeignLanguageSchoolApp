using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.IntegrationTests
{
    [TestClass]
    public class ClientsControllerTests
    {
        [TestMethod]
        public void AddClient_AddClient_ReturnTrue()
        {
            Clients clients = new Clients() {
                ClientSurname = "а",
                ClientName = "а",
                ClientPatronymic = "а",
                ClientBirthDate = DateTime.Now,
                ClientEmail = "а",
                ClientLogin = "а",
                ClientPassword = "а",
                ClientPhone = "а",
                ClientPhotoLink = "а",
                GenderId = 1,
                ClientUniqueInfo = "а"
            };
            ClientsController clientsController = new ClientsController();
            Assert.IsTrue(clientsController.AddClient(clients));
        }
    }
}

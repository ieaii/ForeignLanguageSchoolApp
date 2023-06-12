using ForeignLanguageSchoolApp.Controllers;
using ForeignLanguageSchoolLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForeignLanguageSchoolLibraryTests.IntegrationTests
{
    [TestClass]
    public class ReviewsControllerTests
    {
        [TestMethod]
        public void AddNewReview_AddReview_ReturnTrue()
        {
            Reviews reviews = new Reviews()
            {
                ReviewMessage = "sd",
                ClientId = 1
            };
            ReviewsController reviewsController = new ReviewsController();
            Assert.IsTrue(reviewsController.AddNewReview(reviews));
        }
    }
}

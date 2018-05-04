using System.Web.Mvc;
using NUnit.Framework;
using PizzaAPI;
using PizzaAPI.Controllers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PizzaAPI.Tests.Controllers
{

    [TestFixture]
    public class WhenLoadingPagesFromTheHomeController
    {
        [Test]
        public void GivenTheRouteIsHome()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        [Test]
        public void GivenTheRouteIsClient()
        {
            // Arrange
            HomeController controller = new HomeController();
        
            // Act
            ViewResult result = controller.Client() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}

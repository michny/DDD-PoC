using System.Web.Mvc;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DDD.CommercePoC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var repo = new Mock<IOrderRepository>();
            var uow = new Mock<IUnitOfWork>();
            HomeController controller = new HomeController(repo.Object, uow.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            var repo = new Mock<IOrderRepository>();
            var uow = new Mock<IUnitOfWork>();
            HomeController controller = new HomeController(repo.Object, uow.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;
            
            // Assert
            if (result == null)
                Assert.Fail("The view result is null!");
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            var repo = new Mock<IOrderRepository>();
            var uow = new Mock<IUnitOfWork>();
            HomeController controller = new HomeController(repo.Object, uow.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

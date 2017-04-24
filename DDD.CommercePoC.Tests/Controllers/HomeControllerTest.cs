using System.Web;
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
        private Mock<ICurrentCart> _currentCartMock;
        private Mock<ICurrentUser> _currentUserMock;
        private Mock<HttpContextBase> _currentContextMock;
        private HomeController _controller;

        [TestInitialize]
        public void TestInit()
        {
            _currentCartMock = new Mock<ICurrentCart>();
            _currentUserMock = new Mock<ICurrentUser>();
            _currentContextMock = new Mock<HttpContextBase>();
            _controller = new HomeController(_currentCartMock.Object, _currentUserMock.Object, _currentContextMock.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange

            // Act
            ViewResult result = _controller.About() as ViewResult;
            
            // Assert
            if (result == null)
                Assert.Fail("The view result is null!");
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.Events;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;
using DDD.CommercePoC.Shop.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DDD.CommercePoC.Shop.Tests
{
    [TestClass]
    public class OrderTests
    {
        private static WindsorContainer _container;
        private static Mock<IHandle<OrderPlacedEvent>> _placedEventHandlerMock;
        private static Mock<IHandle<OrderCancelledEvent>> _cancelledEventHandlerMock;


        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _container = new WindsorContainer();
            DomainEvents.Initialize(_container);

            _placedEventHandlerMock = new Mock<IHandle<OrderPlacedEvent>>();
            _cancelledEventHandlerMock = new Mock<IHandle<OrderCancelledEvent>>();
            _container.Register(Component.For<IHandle<OrderPlacedEvent>>().Instance(_placedEventHandlerMock.Object));
            _container.Register(Component.For<IHandle<OrderCancelledEvent>>().Instance(_cancelledEventHandlerMock.Object));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _placedEventHandlerMock.ResetCalls();
            _cancelledEventHandlerMock.ResetCalls();
        }

        [TestMethod]
        public void OrderSuccessfullyPlacedFromNonEmptyCart()
        {
            //Arrange
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 20));
            var cartLineItem1 = new CartLineItem(Guid.NewGuid(), cart.Id, variant1, 2);
            cart.CartLineItems.Add(cartLineItem1);
            var cartLineItem2 = new CartLineItem(Guid.NewGuid(), cart.Id, variant2, 3);
            cart.CartLineItems.Add(cartLineItem2);

            var cartRepoMock = new Mock<ICartRepository>();
            var orderRepoMock = new Mock<IOrderRepository>();
            var priceServiceMock = new Mock<IPriceService>();
            priceServiceMock.Setup(service => service.GetCartLineItemPrice(cartLineItem1)).Returns(new Money(Currency.Dkk, 20));
            priceServiceMock.Setup(service => service.GetCartLineItemPrice(cartLineItem2)).Returns(new Money(Currency.Dkk, 60));
            priceServiceMock.Setup(service => service.GetTotalCartPrice(cart)).Returns(new Money(Currency.Dkk, 80));
            var orderService = new OrderService(cartRepoMock.Object, orderRepoMock.Object, priceServiceMock.Object);

            //Act
            var order = orderService.PlaceOrder(cart);

            //Assert
            Assert.AreEqual(cart.CustomerId, order.CustomerId);
            Assert.AreEqual(new Money(Currency.Dkk, 80), order.Total);
            Assert.AreEqual(cart.CartLineItems.Count, order.OrderLineItems.Count);
            foreach (var cartLineItem in cart.CartLineItems)
            {
                var matchingOrderLineItem = order.OrderLineItems.Single(cli => cli.VariantId == cartLineItem.VariantId);
                Assert.IsNotNull(matchingOrderLineItem);
                Assert.AreEqual(cartLineItem.Count, matchingOrderLineItem.Count);
            }

            _placedEventHandlerMock.Verify(e => e.Handle(It.IsAny<OrderPlacedEvent>()), Times.Once);
            _cancelledEventHandlerMock.Verify(e => e.Handle(It.IsAny<OrderCancelledEvent>()), Times.Never);
        }
    }
}

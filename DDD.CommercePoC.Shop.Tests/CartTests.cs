using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Exceptions;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.Events;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DDD.CommercePoC.Shop.Tests
{
    [TestClass]
    public class CartTests
    {
        private static WindsorContainer _container;
        private static Mock<IHandle<CartLineItemAddedEvent>> _addedEventHandlerMock;
        private static Mock<IHandle<CartLineItemUpdatedEvent>> _updatedEventHandlerMock;
        private static Mock<IHandle<CartLineItemDeletedEvent>> _deletedEventHandlerMock;

        #region Initialization

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _container = new WindsorContainer();
            DomainEvents.Initialize(_container);

            _addedEventHandlerMock = new Mock<IHandle<CartLineItemAddedEvent>>();
            _updatedEventHandlerMock = new Mock<IHandle<CartLineItemUpdatedEvent>>();
            _deletedEventHandlerMock = new Mock<IHandle<CartLineItemDeletedEvent>>();
            _container.Register(Component.For<IHandle<CartLineItemAddedEvent>>().Instance(_addedEventHandlerMock.Object));
            _container.Register(Component.For<IHandle<CartLineItemUpdatedEvent>>().Instance(_updatedEventHandlerMock.Object));
            _container.Register(Component.For<IHandle<CartLineItemDeletedEvent>>().Instance(_deletedEventHandlerMock.Object));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _addedEventHandlerMock.ResetCalls();
            _updatedEventHandlerMock.ResetCalls();
            _deletedEventHandlerMock.ResetCalls();
        }

        #endregion

        #region Add Variants

        [TestMethod]
        public void AddVariantToCartAsNewCartLineItem()
        {
            //Arrange
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant1));

            //Act
            cart.AddVariant(variant2);

            //Assert
            Assert.AreEqual(2, cart.CartLineItems.Count);
            Assert.AreEqual(1, cart.CartLineItems.Single(e => e.VariantId == variant2.Id).Count);
            _addedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemAddedEvent>()), Times.Once);
            _updatedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemUpdatedEvent>()), Times.Never);
            _deletedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemDeletedEvent>()), Times.Never);
        }

        [TestMethod]
        public void AddVariantToCartToExistingCartLineItem()
        {
            //Arrange
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant1));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant2));

            //Act
            cart.AddVariant(variant2);

            //Assert
            Assert.AreEqual(2, cart.CartLineItems.Count);
            Assert.AreEqual(2, cart.CartLineItems.Single(e => e.VariantId == variant2.Id).Count);
            _addedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemAddedEvent>()), Times.Never);
            _updatedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemUpdatedEvent>()), Times.Once);
            _deletedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemDeletedEvent>()), Times.Never);
        }

        #endregion

        #region Remove Variants

        [TestMethod]
        public void RemoveVariantFromCartResultingInEmptyCartLineItem()
        {
            //Arrange
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant1));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant2));

            //Act
            cart.RemoveVariant(variant2.Id);

            //Assert
            Assert.AreEqual(1, cart.CartLineItems.Count);
            Assert.IsTrue(cart.CartLineItems.All(e => e.VariantId != variant2.Id));
            _addedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemAddedEvent>()), Times.Never);
            _updatedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemUpdatedEvent>()), Times.Never);
            _deletedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemDeletedEvent>()), Times.Once);
        }

        [TestMethod]
        public void RemoveVariantFromCartResultingInNonEmptyCartLineItem()
        {
            //Arrange
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant1));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant2, 2));

            //Act
            cart.RemoveVariant(variant2.Id);

            //Assert
            Assert.AreEqual(2, cart.CartLineItems.Count);
            Assert.AreEqual(1, cart.CartLineItems.Single(e => e.VariantId == variant2.Id).Count);
            _addedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemAddedEvent>()), Times.Never);
            _updatedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemUpdatedEvent>()), Times.Once);
            _deletedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemDeletedEvent>()), Times.Never);
        }

        [TestMethod]
        public void RemoveVariantFromCartThatIsntPresentInCart()
        {
            //Arrange
            var cart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            cart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), cart.Id, variant1));

            //Act
            try
            {
                cart.RemoveVariant(variant2.Id);
                Assert.Fail("Expected exception wasn't raised!");
            }
            catch (VariantNotExistingInCartException ex)
            {
                //Assert
                Assert.AreEqual(variant2.Id, ex.VariantId);
                Assert.AreEqual(cart.Id, ex.CartId);
                Assert.AreEqual(1, cart.CartLineItems.Count);
                Assert.IsTrue(cart.CartLineItems.All(e => e.VariantId != variant2.Id));
                _addedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemAddedEvent>()), Times.Never);
                _updatedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemUpdatedEvent>()), Times.Never);
                _deletedEventHandlerMock.Verify(e => e.Handle(It.IsAny<CartLineItemDeletedEvent>()), Times.Never);
            }
        }

        #endregion

        #region Merge Carts

        [TestMethod]
        public void MergeCartEmptySourceEmptyInputCart()
        {
            //Arrange
            var srcCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            
            var inputCart = new Cart(Guid.NewGuid(), Guid.NewGuid());

            //Act
            srcCart.Merge(inputCart);

            //Assert
            Assert.AreEqual(0, srcCart.CartLineItems.Count);
        }

        [TestMethod]
        public void MergeCartEmptySourceNonEmptyInputCart()
        {
            //Arrange
            var srcCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            srcCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), srcCart.Id, variant1));
            srcCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), srcCart.Id, variant2));

            var inputCart = new Cart(Guid.NewGuid(), Guid.NewGuid());

            //Act
            srcCart.Merge(inputCart);

            //Assert
            Assert.AreEqual(2, srcCart.CartLineItems.Count);
            Assert.AreEqual(1, srcCart.CartLineItems.Single(cli => cli.VariantId == variant1.Id).Count);
            Assert.AreEqual(1, srcCart.CartLineItems.Single(cli => cli.VariantId == variant2.Id).Count);
        }

        [TestMethod]
        public void MergeCartNonEmptySourceNonEmptyInputCartWhereInputCartIsSubset()
        {
            //Arrange
            var srcCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            srcCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), srcCart.Id, variant1));
            srcCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), srcCart.Id, variant2));

            var inputCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            inputCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), inputCart.Id, variant1, 2));

            //Act
            srcCart.Merge(inputCart);

            //Assert
            Assert.AreEqual(2, srcCart.CartLineItems.Count);
            Assert.AreEqual(3, srcCart.CartLineItems.Single(cli => cli.VariantId == variant1.Id).Count);
            Assert.AreEqual(1, srcCart.CartLineItems.Single(cli => cli.VariantId == variant2.Id).Count);
        }

        [TestMethod]
        public void MergeCartNonEmptySourceNonEmptyInputCartWhereSourceCartIsSubset()
        {
            //Arrange
            var srcCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            srcCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), srcCart.Id, variant1));

            var inputCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            inputCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), inputCart.Id, variant1, 2));
            inputCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), inputCart.Id, variant2));

            //Act
            srcCart.Merge(inputCart);

            //Assert
            Assert.AreEqual(2, srcCart.CartLineItems.Count);
            Assert.AreEqual(3, srcCart.CartLineItems.Single(cli => cli.VariantId == variant1.Id).Count);
            Assert.AreEqual(1, srcCart.CartLineItems.Single(cli => cli.VariantId == variant2.Id).Count);
        }

        [TestMethod]
        public void MergeCartNonEmptySourceNonEmptyInputCartWhereBothHaveExclusiveVariants()
        {
            //Arrange
            var srcCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            var variant1 = new Variant("TestVariant1", Guid.NewGuid(), "Test Variant 1", new Money(Currency.Dkk, 10));
            var variant2 = new Variant("TestVariant2", Guid.NewGuid(), "Test Variant 2", new Money(Currency.Dkk, 10));
            var variant3 = new Variant("TestVariant3", Guid.NewGuid(), "Test Variant 3", new Money(Currency.Dkk, 10));
            srcCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), srcCart.Id, variant1));
            srcCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), srcCart.Id, variant3));

            var inputCart = new Cart(Guid.NewGuid(), Guid.NewGuid());
            inputCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), inputCart.Id, variant1, 2));
            inputCart.CartLineItems.Add(new CartLineItem(Guid.NewGuid(), inputCart.Id, variant2));

            //Act
            srcCart.Merge(inputCart);

            //Assert
            Assert.AreEqual(3, srcCart.CartLineItems.Count);
            Assert.AreEqual(3, srcCart.CartLineItems.Single(cli => cli.VariantId == variant1.Id).Count);
            Assert.AreEqual(1, srcCart.CartLineItems.Single(cli => cli.VariantId == variant2.Id).Count);
            Assert.AreEqual(1, srcCart.CartLineItems.Single(cli => cli.VariantId == variant3.Id).Count);
        }

        #endregion
    }
}

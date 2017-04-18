using System;
using System.Linq;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.Events;
using DDD.CommercePoC.Shop.Core.Model.OrderAggregate;

namespace DDD.CommercePoC.Shop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPriceService _priceService;

        public OrderService(ICartRepository cartRepository, IOrderRepository orderRepository, IPriceService priceService)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _priceService = priceService;
        }

        public Order PlaceOrder(Guid cartId)
        {
            var cart = _cartRepository.Single(c => c.Id == cartId);
            return PlaceOrder(cart);
        }

        public Order PlaceOrder(Cart cart)
        {
            var cartLineItemPrices = cart.CartLineItems.ToDictionary(cli => cli.Id, cli => _priceService.GetCartLineItemPrice(cli));

            var order = new Order(Guid.NewGuid(), cart, cartLineItemPrices);
            var price = _priceService.GetTotalCartPrice(cart);
            order.Total = price;
            _orderRepository.Add(order);

            DomainEvents.Raise(new OrderPlacedEvent(order.Id, order.CustomerId));

            return order;
        }
    }
}
using System;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.OrderAggregate;

namespace DDD.CommercePoC.Shop.Core.Interfaces
{
    public interface IOrderService
    {
        Order PlaceOrder(Guid cartId);

        Order PlaceOrder(Cart cart);
    }
}
using System;
using DDD.CommercePoC.SharedKernel.Events;

namespace DDD.CommercePoC.Shop.Core.Model.Events
{
    public class CartLineItemAddedEvent : BaseDomainEvent
    {
        public Guid CartId { get; }
        public Guid OrderItemId { get; }
        public string VariantId { get; }

        public CartLineItemAddedEvent(Guid cartId, Guid orderItemId, string variantId) 
        {
            CartId = cartId;
            OrderItemId = orderItemId;
            VariantId = variantId;
        }
    }
}
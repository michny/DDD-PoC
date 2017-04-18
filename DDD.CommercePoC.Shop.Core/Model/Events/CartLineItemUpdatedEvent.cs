using System;
using DDD.CommercePoC.SharedKernel.Events;

namespace DDD.CommercePoC.Shop.Core.Model.Events
{
    public class CartLineItemUpdatedEvent : BaseDomainEvent
    {
        public Guid CartId { get; }
        public Guid OrderItemId { get; }
        public string VariantId { get; }
        public int NewCount { get; }

        public CartLineItemUpdatedEvent(Guid cartId, Guid orderItemId, string variantId, int newCount)
        {
            CartId = cartId;
            OrderItemId = orderItemId;
            VariantId = variantId;
            NewCount = newCount;
        }
    }
}
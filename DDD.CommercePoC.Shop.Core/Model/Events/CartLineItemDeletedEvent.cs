using System;
using DDD.CommercePoC.SharedKernel.Events;

namespace DDD.CommercePoC.Shop.Core.Model.Events
{
    public class CartLineItemDeletedEvent : BaseDomainEvent
    {
        public Guid CartId { get; }
        public Guid OrderItemId { get; }
        public string VariantId { get; }

        public CartLineItemDeletedEvent(Guid cartId, Guid orderItemId, string variantId)
        {
            CartId = cartId;
            OrderItemId = orderItemId;
            VariantId = variantId;
        }
    }
}
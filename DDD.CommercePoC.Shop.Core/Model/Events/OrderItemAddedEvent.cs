using System;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.Shop.Core.Model.Events
{
    public class OrderItemAddedEvent : IDomainEvent
    {
        public Guid OrderId { get; }
        public Guid OrderItemId { get; }
        public string VariantId { get; }

        public OrderItemAddedEvent(Guid orderId, Guid orderItemId, string variantId)
        {
            OrderId = orderId;
            OrderItemId = orderItemId;
            VariantId = variantId;
            DateTimeEventOccurredUtc = DateTime.UtcNow;
        }
        public DateTime DateTimeEventOccurredUtc { get; }
    }
}
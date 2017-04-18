using System;
using DDD.CommercePoC.SharedKernel.Events;

namespace DDD.CommercePoC.Shop.Core.Model.Events
{
    public class OrderPlacedEvent : BaseDomainEvent
    {
        public Guid OrderId { get; }
        public Guid CustomerId { get; }

        public OrderPlacedEvent(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}
using System;
using DDD.CommercePoC.SharedKernel.Events;

namespace DDD.CommercePoC.Shop.Core.Model.Events
{
    public class OrderCancelledEvent : BaseDomainEvent
    {
        public Guid OrderId { get; }
        public Guid CustomerId { get; }

        public OrderCancelledEvent(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}
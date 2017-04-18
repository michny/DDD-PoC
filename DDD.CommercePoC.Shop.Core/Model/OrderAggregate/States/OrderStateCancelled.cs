using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Model.Events;

namespace DDD.CommercePoC.Shop.Core.Model.OrderAggregate.States
{
    public class OrderStateCancelled : OrderState
    {
        public new static readonly string Name = "Cancelled";

        public OrderStateCancelled() : base(Name)
        {
        }

        public override OrderState RestoreOrder(Order order)
        {
            DomainEvents.Raise(new OrderRestoredEvent(order.Id, order.CustomerId));
            return new OrderStatePlaced();
        }
    }
}
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Model.Events;

namespace DDD.CommercePoC.Shop.Core.Model.OrderAggregate.States
{
    public class OrderStatePlaced : OrderState
    {
        public new static readonly string Name = "Placed";

        public OrderStatePlaced() : base(Name)
        {
        }

        public override OrderState CancelOrder(Order order)
        {
            DomainEvents.Raise(new OrderCancelledEvent(order.Id, order.CustomerId));
            return new OrderStateCancelled();
        }
    }
}
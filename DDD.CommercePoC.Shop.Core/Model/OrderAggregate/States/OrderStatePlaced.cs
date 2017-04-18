using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Model.Events;

namespace DDD.CommercePoC.Shop.Core.Model.OrderAggregate.States
{
    public class OrderStatePlaced : OrderState
    {
        public OrderStatePlaced() : base("Placed")
        {
        }

        public override OrderState CancelOrder(Order order)
        {
            DomainEvents.Raise(new OrderCancelledEvent(order.Id, order.CustomerId));
            return new OrderStateCancelled();
        }
    }
}
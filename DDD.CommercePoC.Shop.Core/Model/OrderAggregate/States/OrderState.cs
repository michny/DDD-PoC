namespace DDD.CommercePoC.Shop.Core.Model.OrderAggregate.States
{
    public abstract class OrderState
    {
        public string Name { get; }

        protected OrderState(string name)
        {
            Name = name;
        }

        public virtual OrderState CancelOrder(Order order)
        {
            return this; //Default implementation is to do nothing, i.e. return same state
        }

        public virtual OrderState RestoreOrder(Order order)
        {
            return this; //Default implementation is to do nothing, i.e. return same state
        }
    }
}
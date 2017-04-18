using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.OrderAggregate.States;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.Shop.Core.Model.OrderAggregate
{
    public class Order : Entity<Guid>, IAggregateRoot
    {
        #region Constructors
        public Order(Guid id, Cart cart, IDictionary<Guid, Money> cartLineItemPrices) : base(id)
        {
            CustomerId = cart.CustomerId;
            OrderLineItems = new List<OrderLineItem>(
                cart.CartLineItems.Select(cartLineItem => ConvertCartLineItemToOrderLineItem(cartLineItem, cartLineItemPrices)));
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private Order() : base(new Guid()) { }
        #endregion

        #region Properties
        public Guid CustomerId { get; private set; }

        public Money Total { get; internal set; }

        public List<OrderLineItem> OrderLineItems { get; private set; } = new List<OrderLineItem>();

        public string StateName { get; private set; }

        [NotMapped]
        public OrderState State
        {
            get => OrderStateFactory.GetState(StateName);
            private set => StateName = value.GetType().Name;
        }

        [NotMapped]
        public bool IsActive => State.GetType() == typeof(OrderStatePlaced); //TODO Update this with additional states that should be considered active
        #endregion
        
        #region Methods
        private static OrderLineItem ConvertCartLineItemToOrderLineItem(CartLineItem cartLineItem, IDictionary<Guid, Money> cartLineItemPrices)
        {
            return new OrderLineItem(Guid.NewGuid(), cartLineItem, cartLineItemPrices[cartLineItem.Id]);
        }

        public void Cancel() => State = State.CancelOrder(this);

        public void Restore() => State = State.RestoreOrder(this);
        #endregion
    }
}
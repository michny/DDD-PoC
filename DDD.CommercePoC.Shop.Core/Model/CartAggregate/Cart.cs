using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Castle.Core.Internal;
using DDD.CommercePoC.SharedKernel.Enums;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;
using DDD.CommercePoC.Shop.Core.Exceptions;
using DDD.CommercePoC.Shop.Core.Model.Events;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;

namespace DDD.CommercePoC.Shop.Core.Model.CartAggregate
{
    public class Cart : Entity<Guid>, IAggregateRoot
    {
        #region Ctrs

        public Cart(Guid id, Guid customerId) : base(id)
        {
            CustomerId = customerId;
            //Total = new Money(Currency.Dkk, 0m);
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private Cart() : base(Guid.NewGuid())
        {
            //Total = new Money(Currency.Dkk, 0m);
        }

        #endregion

        #region Properties

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local : Private set required by EF for Code First migrations
        //public ICollection<OrderItem> OrderItems { get; private set; }
        //private List<CartLineItem> _cartLineItems;
        //public virtual ICollection<CartLineItem> CartLineItems
        //{
        //    get => _cartLineItems;//.AsReadOnly();
        //    private set => _cartLineItems = (List<CartLineItem>)value;
        //}
        public virtual ICollection<CartLineItem> CartLineItems { get; set; } = new List<CartLineItem>();


        [Required]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local : Private set required by EF for Code First migrations
        public Guid CustomerId { get; private set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        protected virtual Customer Customer { get; private set; }

        //[Required]
        //public Money Total { get; private set; }

        #endregion

        #region Methods

        public Variant AddVariant(Variant variant)
        {
            Guid cartLineItemId;
            var existingCartLineItem = CartLineItems.SingleOrDefault(item => item.VariantId == variant.Id);
            if (existingCartLineItem != null)
            {
                cartLineItemId = existingCartLineItem.Id;
                existingCartLineItem.IncreaseCount();
                DomainEvents.Raise(new CartLineItemUpdatedEvent(Id, cartLineItemId, variant.Id, existingCartLineItem.Count));
            }
            else
            {
                cartLineItemId = Guid.NewGuid();
                CartLineItems.Add(new CartLineItem(cartLineItemId, Id, variant));
                DomainEvents.Raise(new CartLineItemAddedEvent(Id, cartLineItemId, variant.Id));
            }

            return variant;
        }

        public void RemoveVariant(string variantId)
        {
            var existingCartLineItem = CartLineItems.SingleOrDefault(item => item.VariantId == variantId);
            if (existingCartLineItem == null)
                throw new VariantNotExistingInCartException(Id, variantId);
            
            existingCartLineItem.DecreaseCount();
            if (existingCartLineItem.Count == 0)
            {
                DeleteCartLineItem(existingCartLineItem);
            }
            else
            {
                DomainEvents.Raise(new CartLineItemUpdatedEvent(Id, existingCartLineItem.Id, variantId, existingCartLineItem.Count));
            }
        }

        public void Clear()
        {
            CartLineItems.ForEach(DeleteCartLineItem);
        }

        private void DeleteCartLineItem(CartLineItem cartLineItem)
        {
            cartLineItem.TrackingState = TrackingState.Deleted;
            CartLineItems.Remove(cartLineItem);
            DomainEvents.Raise(new CartLineItemDeletedEvent(Id, cartLineItem.Id, cartLineItem.VariantId));
        }

        #endregion
    }
}

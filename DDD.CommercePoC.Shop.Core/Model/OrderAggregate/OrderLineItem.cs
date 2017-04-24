using System;
using System.ComponentModel.DataAnnotations;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.Shop.Core.Model.OrderAggregate
{
    public class OrderLineItem : Entity<Guid>
    {
        public OrderLineItem(Guid id, CartLineItem cartLineItem, Money price) : base(id)
        {
            VariantId = cartLineItem.VariantId;
            Count = cartLineItem.Count;
            LineTotal = price;
        }
        
        [Required]
        public string VariantId { get; private set; }

        [Required]
        public int Count { get; private set; }

        [Required]
        public Money LineTotal { get; private set; }
    }
}
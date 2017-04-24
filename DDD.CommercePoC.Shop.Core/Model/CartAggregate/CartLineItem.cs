using System;
using System.ComponentModel.DataAnnotations;
using DDD.CommercePoC.SharedKernel.Enums;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;

namespace DDD.CommercePoC.Shop.Core.Model.CartAggregate
{
    public class CartLineItem : Entity<Guid>
    {
        public CartLineItem(Guid id, Guid cartId, Variant variant, int count = 1) : this(id, cartId, variant.Id, count)
        {
        }

        public CartLineItem(Guid id, Guid cartId, string variantId, int count = 1) : base(id)
        {
            CartId = cartId;
            VariantId = variantId;
            Count = count;
            TrackingState = TrackingState.Added;
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private CartLineItem() : base(Guid.NewGuid()) { }

        [Required]
        public Guid CartId { get; private set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        protected virtual Cart Cart { get; private set; }

        [Required]
        public string VariantId { get; private set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        protected virtual Variant Variant { get; private set; }
        
        [Required]
        public int Count { get; private set; }
        
        public void IncreaseCount(int increment = 1)
        {
            Count += increment;
            TrackingState = TrackingState.Modified;
        }

        public void DecreaseCount(int decrement = 1)
        {
            Count -= decrement;
            TrackingState = TrackingState.Modified;
        }
    }
}
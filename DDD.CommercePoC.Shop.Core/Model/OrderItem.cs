using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DDD.CommercePoC.SharedKernel.Enums;
using DDD.CommercePoC.SharedKernel.Model;

namespace DDD.CommercePoC.Shop.Core.Model
{
    public class OrderItem : Entity<Guid>
    {
        public OrderItem(Guid id, Guid orderId, string variantId, int count = 1) : base(id)
        {
            OrderId = orderId;
            VariantId = variantId;
            Count = count;
            State = TrackingState.Added;
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private OrderItem() : base(Guid.NewGuid()) { }

        [Required]
        public Guid OrderId { get; private set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        protected virtual Order Order { get; private set; }

        [Required]
        public string VariantId { get; private set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        public virtual Variant Variant { get; private set; }
        
        [Required]
        public int Count { get; private set; }

        [NotMapped]
        public TrackingState State { get; set; }

        public void IncreaseCount(int increment = 1)
        {
            Count += increment;
            State = TrackingState.Modified;
        }
    }
}
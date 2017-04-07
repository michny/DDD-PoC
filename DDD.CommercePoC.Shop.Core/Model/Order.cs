using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.Events;

namespace DDD.CommercePoC.Shop.Core.Model
{
    public class Order : Entity<Guid>, IAggregateRoot
    {
        #region Ctrs

        public Order(Guid id, Guid customerId) : base(id)
        {
            CustomerId = customerId;
            OrderItems = new List<OrderItem>();
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private Order() : base(Guid.NewGuid())
        {
            OrderItems = new List<OrderItem>();
        }

        #endregion

        #region Properties

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local : Private set required by EF for Code First migrations
        public ICollection<OrderItem> OrderItems { get; private set; }

        [Required]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local : Private set required by EF for Code First migrations
        public Guid CustomerId { get; private set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        public virtual Customer Customer { get; private set; }

        #endregion

        #region Methods

        public Variant AddVariant(Variant variant)
        {
            Guid orderItemId;
            var existingOrderItem = OrderItems.SingleOrDefault(item => item.VariantId == variant.Id);
            if (existingOrderItem != null)
            {
                orderItemId = existingOrderItem.Id;
                existingOrderItem.IncreaseCount();
            }
            else
            {
                orderItemId = Guid.NewGuid();
                OrderItems.Add(new OrderItem(orderItemId, Id, variant.Id));
            }

            DomainEvents.Raise(new OrderItemAddedEvent(Id, orderItemId, variant.Id));

            return variant;
        }

        #endregion
    }
}

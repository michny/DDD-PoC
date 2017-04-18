using System;
using System.ComponentModel.DataAnnotations;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.Shop.Core.Model.ProductAggregate
{
    public class Variant : Entity<string>
    {
        public Variant(string id, Guid productId, string name, Money price) : base(id)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private Variant() { }

        [Required]
        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        public string Name { get; private set; }

        [Required]
        public Guid ProductId { get; private set; }

        public Money Price { get; private set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        protected virtual Product Product { get; private set; }
    }
}
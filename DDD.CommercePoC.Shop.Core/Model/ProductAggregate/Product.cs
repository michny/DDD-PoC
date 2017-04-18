using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.Shop.Core.Model.ProductAggregate
{
    public class Product : Entity<Guid>, IAggregateRoot
    {
        public Product(Guid id, string name) : base(id)
        {
            Name = name;
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private Product() { }

        [Required]
        public string Name { get; private set; }

        //private List<Variant> _variants;

        //public virtual IEnumerable<Variant> Variants
        //{
        //    get => _variants.AsEnumerable();
        //    private set => _variants = value.ToList();
        //}
        public virtual ICollection<Variant> Variants { get; set; }
    }
}
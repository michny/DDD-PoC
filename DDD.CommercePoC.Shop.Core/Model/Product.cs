using System;
using System.ComponentModel.DataAnnotations;
using DDD.CommercePoC.SharedKernel.Model;

namespace DDD.CommercePoC.Shop.Core.Model
{
    public class Product : Entity<Guid>
    {
        public Product(Guid id, string name) : base(id)
        {
            Name = name;
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private Product() { }

        [Required]
        public string Name { get; private set; }
    }
}
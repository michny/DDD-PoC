using System;
using System.ComponentModel.DataAnnotations;
using DDD.CommercePoC.SharedKernel.Model;

namespace DDD.CommercePoC.Shop.Core.Model
{
    public class Customer : Entity<Guid>
    {
        public Customer(Guid id) : base(id)
        {
            
        }

        // ReSharper disable once UnusedMember.Local : Reguired by EF
        private Customer() { }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        public string Name { get; private set; }
    }
}
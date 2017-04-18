using System;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.Shop.Core.Model
{
    public class Customer : Entity<Guid>, IAggregateRoot
    {
        public Customer(Guid id, string name) : base(id)
        {
            Name = name;
        }

        // ReSharper disable once UnusedMember.Local : Reguired by EF
        private Customer() { }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local : Private set required by EF for Code First migrations
        public string Name { get; private set; }
    }
}
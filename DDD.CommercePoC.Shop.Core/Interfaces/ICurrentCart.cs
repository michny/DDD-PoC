using System;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;

namespace DDD.CommercePoC.Shop.Core.Interfaces
{
    public interface ICurrentCart
    {
        Cart Cart { get; }

        Guid Id { get; set; }
    }
}
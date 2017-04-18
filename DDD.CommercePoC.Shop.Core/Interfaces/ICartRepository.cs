using System;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using JetBrains.Annotations;

namespace DDD.CommercePoC.Shop.Core.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        void Update(Cart cart);

        [NotNull]
        IQueryable<Cart> ManyWithCartLineItems([CanBeNull]Expression<Func<Cart, bool>> predicate = null);

        [NotNull]
        Cart GetCartForCustomer(Guid customerId);
    }
}
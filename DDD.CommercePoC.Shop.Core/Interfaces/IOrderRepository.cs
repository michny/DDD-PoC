using System;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Model;
using JetBrains.Annotations;

namespace DDD.CommercePoC.Shop.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);

        [NotNull]
        IQueryable<Order> ManyWithOrderItems([CanBeNull]Expression<Func<Order, bool>> predicate = null);
    }
}
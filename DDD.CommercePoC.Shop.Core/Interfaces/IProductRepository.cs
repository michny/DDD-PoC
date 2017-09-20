using System;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using JetBrains.Annotations;

namespace DDD.CommercePoC.Shop.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> ManyWithVariants([CanBeNull] Expression<Func<Product, bool>> predicate = null);

        Product SingleWithVariants(Expression<Func<Product, bool>> predicate);
    }
}
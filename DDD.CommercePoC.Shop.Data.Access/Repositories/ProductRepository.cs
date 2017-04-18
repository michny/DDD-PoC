using System;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;

namespace DDD.CommercePoC.Shop.Data.Access.Repositories
{
    public class ProductRepository : SqlDatabaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }


        public IQueryable<Product> ManyWithVariants(Expression<Func<Product, bool>> predicate = null)
        {
            return Many(predicate, includes: product => product.Variants);
        }
    }
}
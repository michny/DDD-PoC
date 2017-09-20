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
            var products = Many(predicate, includes: product => product.Variants);
            //foreach (var variant in products.SelectMany(p => p.Variants))
            //{
            //    DatabaseContext.Entry(variant).Collection(p => p.ImageUrls).Load();
            //}
            return products;
        }

        public Product SingleWithVariants(Expression<Func<Product, bool>> predicate)
        {
            var product = Single(predicate, includes: p => p.Variants);
            //foreach (var variant in product.Variants)
            //{
            //    DatabaseContext.Entry(variant).Collection(p => p.ImageUrls).Load();
            //}
            return product;
        }
    }
}
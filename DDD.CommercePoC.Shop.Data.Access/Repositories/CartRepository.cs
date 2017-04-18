using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.SharedKernel.Enums;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;

namespace DDD.CommercePoC.Shop.Data.Access.Repositories
{
    public class CartRepository : SqlDatabaseRepository<Cart>, ICartRepository
    {
        private readonly IDatabaseContext _context;

        public CartRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
            _context = databaseContext;
        }

        public void Update(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;

            foreach (var orderItem in cart.CartLineItems)
            {
                if (orderItem.State == TrackingState.Added)
                {
                    _context.Entry(orderItem).State = EntityState.Added;
                }
                if (orderItem.State == TrackingState.Modified)
                {
                    _context.Entry(orderItem).State = EntityState.Modified;
                }
                if (orderItem.State == TrackingState.Deleted)
                {
                    _context.Entry(orderItem).State = EntityState.Deleted;
                }
            }
            //_context.SaveChanges();
        }

        public IQueryable<Cart> ManyWithCartLineItems(Expression<Func<Cart, bool>> predicate = null)
        {
            return Many(predicate, includes: cart => cart.CartLineItems);
        }

        public Cart GetCartForCustomer(Guid customerId)
        {
            return Single(cart => cart.CustomerId == customerId);
        }
    }
}
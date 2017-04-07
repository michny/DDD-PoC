using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.SharedKernel.Enums;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model;

namespace DDD.CommercePoC.Shop.Data.Access.Repositories
{
    public class OrderRepository : SqlDatabaseRepository<Order>, IOrderRepository
    {
        private readonly IDatabaseContext _context;

        public OrderRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
            _context = databaseContext;
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;

            foreach (var orderItem in order.OrderItems)
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

        public IQueryable<Order> ManyWithOrderItems(Expression<Func<Order, bool>> predicate = null)
        {
            return Many(predicate, includes: order => order.OrderItems);
        }
    }
}
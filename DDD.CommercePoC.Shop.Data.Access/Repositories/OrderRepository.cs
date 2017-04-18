using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.OrderAggregate;

namespace DDD.CommercePoC.Shop.Data.Access.Repositories
{
    public class OrderRepository : SqlDatabaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
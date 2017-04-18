using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.OrderAggregate;

namespace DDD.CommercePoC.Shop.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        
    }
}
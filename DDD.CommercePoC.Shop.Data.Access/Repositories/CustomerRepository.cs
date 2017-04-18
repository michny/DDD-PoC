using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model;

namespace DDD.CommercePoC.Shop.Data.Access.Repositories
{
    public class CustomerRepository : SqlDatabaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
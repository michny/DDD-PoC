using System.Data.Entity;
using DDD.CommercePoC.SharedKernel.Data.Access.QueryModifications;

namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration.Configuration
{
    public class MasterDbConfiguration : DbConfiguration
    {
        public MasterDbConfiguration()
        {
            AddInterceptor(new CreatedAndModifiedDateInterceptor());
        }
    }
}
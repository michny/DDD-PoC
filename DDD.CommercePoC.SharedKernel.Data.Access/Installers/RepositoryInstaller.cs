using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Data.Access.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IReadOnlyRepository<>)).ImplementedBy(typeof(SqlDatabaseReadOnlyRepository<>)));
        }
    }
}
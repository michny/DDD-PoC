using System.Linq;
using Castle.DynamicProxy.Internal;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.Shop.Data.Access.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Types.FromAssemblyNamed("DDD.CommercePoC.Shop.Data.Access")
                .Where(e => e.GetAllInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>)))
                .WithServiceAllInterfaces());
        }
    }
}
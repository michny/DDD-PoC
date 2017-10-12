using System.Linq;
using Castle.DynamicProxy.Internal;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace DDD.CommercePoC.Shop.Core.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Types.FromThisAssembly()
                .Where(e => e.GetInterfaces().Any(i => i.Name.EndsWith("Service")))
                //.Where(type => type.Name.EndsWith("Service"))
                .WithServiceAllInterfaces()
                .LifestylePerWebRequest());
        }
    }
}
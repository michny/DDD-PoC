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
                .Where(type => type.Name.EndsWith("Service"))
                .WithServiceAllInterfaces()
                .LifestylePerWebRequest());
        }
    }
}
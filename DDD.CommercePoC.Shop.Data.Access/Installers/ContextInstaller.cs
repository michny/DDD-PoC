using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Data.Access;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.Shop.Data.Access.Installers
{
    public class ContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDatabaseContext, IUnitOfWork>().ImplementedBy<ShopContext>().LifestylePerWebRequest());
        }
    }
}
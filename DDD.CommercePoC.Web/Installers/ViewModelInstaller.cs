using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DDD.CommercePoC.Web.Models.CartModels;

namespace DDD.CommercePoC.Web.Installers
{
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<CartViewModelFactory>());
        }
    }
}
using System.Linq;
using Castle.DynamicProxy.Internal;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DDD.CommercePoC.Web.Models;

namespace DDD.CommercePoC.Web.Installers
{
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Types.FromThisAssembly()
                .Where(e => e.GetAllInterfaces().Any(
                    i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IViewModelFactory<,>))));

            //container.Register(Component.For<CartViewModelFactory>());
        }
    }
}
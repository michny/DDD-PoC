using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Web.Infrastructure;

namespace DDD.CommercePoC.Web.Installers
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<HttpSessionStateWrapper>()
                .UsingFactoryMethod(() => HttpContext.Current.Session != null ? new HttpSessionStateWrapper(HttpContext.Current.Session) : null));

            container.Register(Component.For<HttpContextWrapper>()
                .UsingFactoryMethod(() => HttpContext.Current != null ? new HttpContextWrapper(HttpContext.Current) : null));

            container.Register(Component.For<ICurrentUser>().ImplementedBy<WebCurrentUser>().LifestylePerWebRequest());

            container.Register(Component.For<ICurrentCart>().ImplementedBy<WebCurrentCart>().LifestylePerWebRequest());
        }
    }
}
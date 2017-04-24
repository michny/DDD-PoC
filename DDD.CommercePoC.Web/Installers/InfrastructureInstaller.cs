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
            container.Register(Component.For<HttpSessionStateBase>()
                .UsingFactoryMethod<HttpSessionStateBase>(
                    () =>
                    {
                        if (HttpContext.Current.Session != null)
                            return new HttpSessionStateWrapper(HttpContext.Current.Session);
                        return new EmptyHttpSessionState();
                    }
                ));

            container.Register(Component.For<HttpContextBase>()
                .UsingFactoryMethod<HttpContextBase>(
                    () =>
                    {
                        if (HttpContext.Current != null)
                            return new HttpContextWrapper(HttpContext.Current);
                        return new EmptyHttpContext();
                    }
                ));

            container.Register(Component.For<ICurrentUser>().ImplementedBy<WebCurrentUser>().LifestylePerWebRequest());

            container.Register(Component.For<ICurrentCart>().ImplementedBy<WebCurrentCart>().LifestylePerWebRequest());
        }
    }
}
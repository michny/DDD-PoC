using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.Core;
using Castle.Windsor;
using Castle.Windsor.Installer;
using DDD.CommercePoC.SharedKernel.Extensions;

namespace DDD.CommercePoC.Web
{
    public static class IoCConfig
    {
        public static IWindsorContainer Configure()
        {
            var container = new WindsorContainer();
            container.SetDefaultLifestyleTo(LifestyleType.Transient);

            container.Install(FromAssembly.Named("DDD.CommercePoC.Web"));
            container.Install(FromAssembly.Named("DDD.CommercePoC.SharedKernel"));
            container.Install(FromAssembly.Named("DDD.CommercePoC.SharedKernel.Data.Access"));
            container.Install(FromAssembly.Named("DDD.CommercePoC.Shop.Data.Access"));
            container.Install(FromAssembly.Named("DDD.CommercePoC.Shop.Core"));

            //container.Install(FromAssembly.InThisApplication());
            
            var controllerFactory = new WindsorControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            //Setting up use of custom Castle Windsor HttpController factory
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(container));

            return container;
        }
    }
}
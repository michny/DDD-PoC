using System.Web.Http.Controllers;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace DDD.CommercePoC.Web.Installers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<Controller>().LifestyleTransient());

            //Ensuring that all HttpControllers are constructed as new objects each time they are requested
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IHttpController>()
                .LifestyleTransient()
                );
        }
    }
}
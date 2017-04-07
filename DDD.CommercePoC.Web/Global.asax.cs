using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Core.Internal;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Data.Access.Migration;
using DDD.CommercePoC.SharedKernel.Model;
using DDD.CommercePoC.SharedKernel.Tasks;

namespace DDD.CommercePoC.Web
{
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _container = IoCConfig.Configure();

            LoggingConfig.Configure(Server);

            MappingConfig.Configure();

            DomainEvents.Initialize(_container);

            EagerMigration();

            RunTasksOnStartup();
        }

        protected void Application_Error()
        {
            RunTasksOnError();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            RunTasksOnRequest();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            RunTasksAfterRequest();
        }

        protected void Application_End()
        {
            RunTasksOnAppEnd();
        }

        private void EagerMigration()
        {
            //Ensuring migration for MasterContext
            var context = new MasterContext();
            // ReSharper disable once UnusedVariable : Required for eager migration
            var eagerMigration = context.Orders.ToList();
        }

        #region Tasks
        private void RunTasksOnStartup()
        {
            _container.ResolveAll<IRunOnStartup>().ForEach(task => task.Execute());
        }

        private void RunTasksOnError()
        {
            _container.ResolveAll<IRunOnError>().ForEach(task => task.Execute());
        }

        private void RunTasksOnRequest()
        {
            _container.ResolveAll<IRunOnRequest>().ForEach(task => task.Execute());
        }

        private void RunTasksAfterRequest()
        {
            _container.ResolveAll<IRunAfterRequest>().ForEach(task => task.Execute());
        }

        private void RunTasksOnAppEnd()
        {
            _container.ResolveAll<IRunOnAppEnd>().ForEach(task => task.Execute());
        }
        #endregion
    }
}

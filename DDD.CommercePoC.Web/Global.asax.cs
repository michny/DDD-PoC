using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
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

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            RunTasksAfterAuth();
        }

        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiRequest())
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        private bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath?.StartsWith(WebApiConfig.UrlPrefixRelative) == true;
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            RunTasksOnRequestRightBeforeCustomCode();
        }

        protected void Application_End()
        {
            RunTasksOnAppEnd();
        }

        protected void Session_Start()
        {
            RunTasksOnNewSession();
        }

        private void EagerMigration()
        {
            //Ensuring migration for MasterContext
            var context = new MasterContext();
            // ReSharper disable once UnusedVariable : Required for eager migration
            var eagerMigration = context.Products.ToList();
        }

        #region Tasks
        private void RunTasksOnStartup()
        {
            _container.ResolveAll<IRunOnStartup>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        private void RunTasksOnError()
        {
            _container.ResolveAll<IRunOnError>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        private void RunTasksOnNewSession()
        {
            _container.ResolveAll<IRunOnNewSession>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        private void RunTasksOnRequest()
        {
            _container.ResolveAll<IRunOnRequest>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        private void RunTasksAfterAuth()
        {
            _container.ResolveAll<IRunAfterAuth>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        private void RunTasksAfterRequest()
        {
            _container.ResolveAll<IRunAfterRequest>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        private void RunTasksOnAppEnd()
        {
            _container.ResolveAll<IRunOnAppEnd>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        private void RunTasksOnRequestRightBeforeCustomCode()
        {
            _container.ResolveAll<IRunOnRequestRightBeforeCustomCode>().OrderBy(task => task.Order).ForEach(task => task.Execute());
        }

        #endregion
    }
}

using System;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Tasks;

namespace DDD.CommercePoC.SharedKernel.Installers
{
    public class TaskInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterTasks(container, typeof(IRunOnStartup));
            RegisterTasks(container, typeof(IRunOnAppEnd));
            
            RegisterTasks(container, typeof(IRunOnNewSession));

            RegisterTasks(container, typeof(IRunOnRequest));
            RegisterTasks(container, typeof(IRunAfterAuth));
            RegisterTasks(container, typeof(IRunOnRequestRightBeforeCustomCode));
            RegisterTasks(container, typeof(IRunAfterRequest));

            RegisterTasks(container, typeof(IRunOnError));
        }

        private void RegisterTasks(IWindsorContainer container, Type interfaceType)
        {
            container.Register(Types.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.AppDomainAppPath + "bin"))
                .Where(type => type.GetInterfaces().Any(i => i == interfaceType))
                    .WithServiceAllInterfaces()
                    .LifestyleTransient());
        }
    }
}
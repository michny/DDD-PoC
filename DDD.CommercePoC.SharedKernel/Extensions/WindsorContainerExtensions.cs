using Castle.Core;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Exceptions;

namespace DDD.CommercePoC.SharedKernel.Extensions
{
    public static class WindsorContainerExtensions
    {
        public static void SetDefaultLifestyleTo(this IWindsorContainer container, LifestyleType lifestyle)
        {
            container.Kernel.ComponentModelCreated += delegate (ComponentModel model)
            {
                if (model.LifestyleType == LifestyleType.Undefined)
                {
                    model.LifestyleType = lifestyle;
                }
            };
        }

        public static void ValidateLifestyles(this IWindsorContainer container)
        {
            var errors = new ContainerLifeStyleException();
            var comparer = new LifeStyleComparer();

            foreach (var node in container.Kernel.GraphNodes)
            {
                var component = (ComponentModel)node;
                foreach (var dependent in node.Dependents)
                {
                    var dependentComponent = (ComponentModel)dependent;
                    if (comparer.Compare(component.LifestyleType, dependentComponent.LifestyleType) > 0)
                        errors.Errors.Add(component, dependentComponent);
                }
            }

            if (errors.ContainsErrors)
                throw errors;
        }
    }
}
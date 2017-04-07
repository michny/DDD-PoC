using System;
using System.Collections.Generic;
using Castle.Windsor;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Model
{
    /// <summary>
    /// http://msdn.microsoft.com/en-gb/magazine/ee236415.aspx#id0400046
    /// </summary>
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> _actions;

        private static IWindsorContainer _container;

        public static void Initialize(IWindsorContainer container)
        {
            _container = container;
        }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (_actions == null)
            {
                _actions = new List<Delegate>();
            }
            _actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            _actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            foreach (var handler in _container.ResolveAll<IHandle<T>>())
            {
                handler.Handle(args);
            }

            if (_actions != null)
            {
                foreach (var action in _actions)
                {
                    var action1 = action as Action<T>;
                    action1?.Invoke(args);
                }
            }
        }
    }
}

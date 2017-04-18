using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DDD.CommercePoC.Shop.Core.Model.OrderAggregate.States
{
    public static class OrderStateFactory
    {
        private static readonly Dictionary<string, OrderState> StatesCache = FindAllDerivedStates();

        public static OrderState GetState(string stateTypeName)
        {
            return StatesCache[stateTypeName];
        }

        private static Dictionary<string, OrderState> FindAllDerivedStates()
        {
            var derivedType = typeof(OrderState);
            var assembly = Assembly.GetAssembly(typeof(OrderState));
            return assembly.GetTypes().Where(t => t != derivedType && derivedType.IsAssignableFrom(t))
                .Select(t => (OrderState)Activator.CreateInstance(t))
                .ToDictionary(k => k.Name);
        }
    }
}
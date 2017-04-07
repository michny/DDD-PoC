using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.CommercePoC.SharedKernel.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this object value)
        {
            if (!(value.GetType().BaseType == typeof(Enum)))
                throw new ArgumentException("Can only convert an instance of enum", nameof(value));

            var name = value.ToString();
            var attrs = value.GetType().GetField(name).GetCustomAttributes(typeof(DisplayAttribute), false);
            return attrs.Length > 0 ? ((DisplayAttribute)attrs[0]).Name : name;
        }

        public static string Description(this object value)
        {
            if (!(value.GetType().BaseType == typeof(Enum)))
                throw new ArgumentException("Can only convert an instance of enum", nameof(value));

            var name = value.ToString();
            var attrs = value.GetType().GetField(name).GetCustomAttributes(typeof(DisplayAttribute), false);
            return attrs.Length > 0 ? ((DisplayAttribute)attrs[0]).Description : name;
        }
    }
}
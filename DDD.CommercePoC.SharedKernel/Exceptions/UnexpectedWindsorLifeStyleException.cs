using System;
using Castle.Core;

namespace DDD.CommercePoC.SharedKernel.Exceptions
{
    public class UnexpectedWindsorLifeStyleException : Exception
    {
        public LifestyleType Type { get; set; }


        public UnexpectedWindsorLifeStyleException(LifestyleType type) : base($"Unexpected life style {type} used in configuration. Either change it or update the LifeStyleComparer accordingly")
        {
            Type = type;
        }
    }
}
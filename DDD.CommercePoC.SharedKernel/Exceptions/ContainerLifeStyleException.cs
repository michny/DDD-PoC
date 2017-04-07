using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core;

namespace DDD.CommercePoC.SharedKernel.Exceptions
{
    public class ContainerLifeStyleException : Exception
    {
        public Dictionary<ComponentModel, ComponentModel> Errors { get; set; } = new Dictionary<ComponentModel, ComponentModel>();

        public bool ContainsErrors => Errors.Any();
    }
}
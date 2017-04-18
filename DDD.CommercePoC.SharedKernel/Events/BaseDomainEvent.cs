using System;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Events
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        protected BaseDomainEvent()
        {
            DateTimeEventOccurredUtc = DateTime.UtcNow;
        }
        public DateTime DateTimeEventOccurredUtc { get; }
    }
}
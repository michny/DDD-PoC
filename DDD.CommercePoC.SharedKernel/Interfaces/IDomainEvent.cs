using System;

namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateTimeEventOccurredUtc { get; }
    }
}
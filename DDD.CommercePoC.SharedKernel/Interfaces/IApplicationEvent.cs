namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface IApplicationEvent : IDomainEvent
    {
        string EventType { get; }
    }
}
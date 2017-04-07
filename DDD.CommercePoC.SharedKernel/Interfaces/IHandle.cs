namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
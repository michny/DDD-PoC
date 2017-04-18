namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunAfterRequest
    {
        void Execute();

        int Order { get; }
    }
}
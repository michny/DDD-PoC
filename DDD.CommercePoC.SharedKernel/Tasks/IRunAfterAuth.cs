namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunAfterAuth
    {
        void Execute();

        int Order { get; }
    }
}
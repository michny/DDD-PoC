namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunOnNewSession
    {
        void Execute();

        int Order { get; }
    }
}
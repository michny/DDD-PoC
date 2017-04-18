namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunOnAppEnd
    {
        void Execute();

        int Order { get; }
    }
}
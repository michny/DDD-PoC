namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunOnError
    {
        void Execute();

        int Order { get; }
    }
}
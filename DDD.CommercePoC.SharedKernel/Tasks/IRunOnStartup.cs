namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunOnStartup
    {
        void Execute();

        int Order { get; }
    }
}
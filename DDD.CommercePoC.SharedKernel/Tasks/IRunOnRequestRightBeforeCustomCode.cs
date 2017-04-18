namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunOnRequestRightBeforeCustomCode
    {
        void Execute();

        int Order { get; }
    }
}
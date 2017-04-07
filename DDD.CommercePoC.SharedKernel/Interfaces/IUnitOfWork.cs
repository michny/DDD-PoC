namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Begins transaction.
        /// </summary>
        ITransaction BeginTransaction();

        /// <summary>
        /// Commits transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks transaction.
        /// </summary>
        void Rollback();
    }
}
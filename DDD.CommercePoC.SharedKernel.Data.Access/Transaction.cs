using System;
using System.Data.Entity;
using System.Runtime.InteropServices;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Data.Access
{
    public class Transaction : ITransaction
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbContextTransaction _transaction;

        public Transaction(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _transaction = dbContext.Database.BeginTransaction();
        }

        internal void Commit()
        {
            _transaction.Commit();
        }

        internal void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            bool isInException = Marshal.GetExceptionPointers() != IntPtr.Zero
                                 || Marshal.GetExceptionCode() != 0;
            if (isInException)
            {
                _dbContext.Rollback();
            }
            else
            {
                _dbContext.Commit();
            }
        }

        internal void DisposeTransaction()
        {
            _transaction.Dispose();
        }
    }
}
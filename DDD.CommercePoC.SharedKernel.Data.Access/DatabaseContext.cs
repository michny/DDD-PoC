using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using DDD.CommercePoC.SharedKernel.Exceptions;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.SharedKernel.Logging;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Data.Access
{
    public abstract class DatabaseContext : DbContext, IDatabaseContext, IUnitOfWork
    {
        private readonly ILogger _logger = LoggingManager.GetLogger();
        private Transaction _transaction;

        static DatabaseContext()
        {
            // ReSharper disable once UnusedVariable : Ensures that EntityFramework.SqlServer.dll gets copied to BIN
            var ensureDllIsCopied = SqlProviderServices.Instance;
        }

        protected DatabaseContext(string connectionString) : base(connectionString) { }
            
        public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class, IEntity
        {
            return Set<TEntity>();
        }

        public void MarkAsModified<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            base.Entry(entity).State = EntityState.Modified;
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity instance) where TEntity : class, IEntity => base.Entry(instance);

        public ITransaction BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = new Transaction(this);
                return _transaction;
            }
            else
            {
                throw new NoOngoingTransactionExistsException();
            }
        }

        public void Commit()
        {
            if (_transaction != null)
            {
                try
                {
                    _logger.Info("Transaction is trying to commit");
                    SaveChanges();
                    _transaction.Commit();
                    _logger.Info("Transaction committed successfully");
                }
                catch (Exception e)
                {
                    _logger.Error("Transaction failed to commit", e);
                    throw;
                }
                finally
                {
                    _transaction.DisposeTransaction();
                    _transaction = null;
                }
            }
            else
            {
                throw new NoOngoingTransactionExistsException();
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.DisposeTransaction();
                _transaction = null;
                _logger.Info("Rolling back transaction");
            }
            else
            {
                throw new NoOngoingTransactionExistsException();
            }
        }
    }
}
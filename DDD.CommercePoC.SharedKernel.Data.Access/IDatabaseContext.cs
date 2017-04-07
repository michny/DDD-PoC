using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Data.Access
{
    public interface IDatabaseContext 
    {
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class, IEntity;
        void MarkAsModified<TEntity>(TEntity entity) where TEntity : class, IEntity;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity instance) where TEntity : class, IEntity;
    }
}
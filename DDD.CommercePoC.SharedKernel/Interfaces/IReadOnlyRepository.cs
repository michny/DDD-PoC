using System;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;
using JetBrains.Annotations;

namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : IEntity
    {
        [CanBeNull]
        TEntity SingleOrDefault([NotNull]Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        [CanBeNull]
        TProjection SingleOrDefault<TProjection>([NotNull]Expression<Func<TEntity, bool>> predicate, [NotNull]Expression<Func<TEntity, TProjection>> projection, params Expression<Func<TEntity, object>>[] includes);

        [NotNull]
        TEntity Single([NotNull]Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        [NotNull]
        TProjection Single<TProjection>([NotNull]Expression<Func<TEntity, bool>> predicate, [NotNull]Expression<Func<TEntity, TProjection>> projection, params Expression<Func<TEntity, object>>[] includes);

        [NotNull]
        IQueryable<TEntity> Many([CanBeNull]Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);

        [NotNull]
        IQueryable<TProjection> Many<TProjection>([NotNull]Expression<Func<TEntity, bool>> predicate, [NotNull]Expression<Func<TEntity, TProjection>> projection, params Expression<Func<TEntity, object>>[] includes);

        bool Exists([CanBeNull]Expression<Func<TEntity, bool>> predicate = null);

        int Count([CanBeNull]Expression<Func<TEntity, bool>> predicate = null);
    }
}
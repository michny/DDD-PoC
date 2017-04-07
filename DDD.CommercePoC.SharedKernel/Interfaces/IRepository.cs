using System;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;
using JetBrains.Annotations;

namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        TAggregateRoot Add([NotNull]TAggregateRoot entity);

        void Remove([NotNull]TAggregateRoot entity);

        [CanBeNull]
        TAggregateRoot SingleOrDefault([NotNull]Expression<Func<TAggregateRoot, bool>> predicate, params Expression<Func<TAggregateRoot, object>>[] includes);

        [CanBeNull]
        TProjection SingleOrDefault<TProjection>([NotNull]Expression<Func<TAggregateRoot, bool>> predicate, [NotNull]Expression<Func<TAggregateRoot, TProjection>> projection, params Expression<Func<TAggregateRoot, object>>[] includes);

        [NotNull]
        TAggregateRoot Single([NotNull]Expression<Func<TAggregateRoot, bool>> predicate, params Expression<Func<TAggregateRoot, object>>[] includes);

        [NotNull]
        TProjection Single<TProjection>([NotNull]Expression<Func<TAggregateRoot, bool>> predicate, [NotNull]Expression<Func<TAggregateRoot, TProjection>> projection, params Expression<Func<TAggregateRoot, object>>[] includes);

        [NotNull]
        IQueryable<TAggregateRoot> Many([CanBeNull]Expression<Func<TAggregateRoot, bool>> predicate = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        [NotNull]
        IQueryable<TProjection> Many<TProjection>([NotNull]Expression<Func<TAggregateRoot, bool>> predicate, [NotNull]Expression<Func<TAggregateRoot, TProjection>> projection, params Expression<Func<TAggregateRoot, object>>[] includes);

        bool Exists([CanBeNull]Expression<Func<TAggregateRoot, bool>> predicate = null);

        int Count([CanBeNull]Expression<Func<TAggregateRoot, bool>> predicate = null);
    }
}
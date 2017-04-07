using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Exceptions;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Data.Access
{
    public class SqlDatabaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        protected IDatabaseContext DatabaseContext { get; }

        public SqlDatabaseRepository(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        public TAggregateRoot Add(TAggregateRoot entity)
        {
            return CreateSet().Add(entity);
        }

        public void Remove(TAggregateRoot entity)
        {
            CreateSet().Remove(entity);
        }

        public TAggregateRoot SingleOrDefault(Expression<Func<TAggregateRoot, bool>> predicate, params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var set = CreateIncludedSet(includes);

            return set.SingleOrDefault(predicate);
        }

        public TProjection SingleOrDefault<TProjection>(Expression<Func<TAggregateRoot, bool>> predicate, Expression<Func<TAggregateRoot, TProjection>> projection, params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var set = CreateIncludedSet(includes);

            return set.Where(predicate).Select(projection).SingleOrDefault();
        }

        public TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> predicate, params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var entity = SingleOrDefault(predicate, includes);

            if (entity == null)
                throw new EntityNotFoundException<TAggregateRoot>(predicate);

            return entity;
        }

        public TProjection Single<TProjection>(Expression<Func<TAggregateRoot, bool>> predicate, Expression<Func<TAggregateRoot, TProjection>> projection, params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var set = CreateIncludedSet(includes);

            return set.Where(predicate).Select(projection).Single();
        }

        public IQueryable<TAggregateRoot> Many(Expression<Func<TAggregateRoot, bool>> predicate = null, params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var set = CreateIncludedSet(includes);

            return predicate == null ? set : set.Where(predicate);
        }

        public IQueryable<TProjection> Many<TProjection>(Expression<Func<TAggregateRoot, bool>> predicate, Expression<Func<TAggregateRoot, TProjection>> projection, params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var set = CreateIncludedSet(includes);

            return set.Where(predicate).Select(projection).AsQueryable();
        }

        public bool Exists(Expression<Func<TAggregateRoot, bool>> predicate = null)
        {
            var set = CreateSet();

            return predicate == null ? set.Any() : set.Any(predicate);
        }

        public int Count(Expression<Func<TAggregateRoot, bool>> predicate = null)
        {
            var set = CreateSet();

            return predicate == null ? set.Count() : set.Count(predicate);
        }

        protected IDbSet<TAggregateRoot> CreateSet()
        {
            return DatabaseContext.CreateSet<TAggregateRoot>();
        }

        protected DbEntityEntry<TAggregateRoot> Entry(TAggregateRoot entity)
        {
            return DatabaseContext.Entry(entity);
        }

        protected IQueryable<TAggregateRoot> CreateIncludedSet(IEnumerable<Expression<Func<TAggregateRoot, object>>> includes)
        {
            IQueryable<TAggregateRoot> set = CreateSet();

            if (includes != null)
                set = includes.Aggregate(set, (current, include) => current.Include(include));

            return set;
        }
    }
}

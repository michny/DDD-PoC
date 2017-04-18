using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Exceptions;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Data.Access
{
    public class SqlDatabaseReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        protected IDatabaseContext DatabaseContext { get; }

        public SqlDatabaseReadOnlyRepository(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = CreateIncludedSet(includes).AsNoTracking();

            return set.SingleOrDefault(predicate);
        }

        public TProjection SingleOrDefault<TProjection>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjection>> projection, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = CreateIncludedSet(includes).AsNoTracking();

            return set.Where(predicate).Select(projection).SingleOrDefault();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = SingleOrDefault(predicate, includes);

            if (entity == null)
                throw new EntityNotFoundException<TEntity>(predicate);

            return entity;
        }

        public TProjection Single<TProjection>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjection>> projection, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = CreateIncludedSet(includes).AsNoTracking();

            return set.Where(predicate).Select(projection).Single();
        }

        public IQueryable<TEntity> Many(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = CreateIncludedSet(includes).AsNoTracking();

            return predicate == null ? set : set.Where(predicate);
        }

        public IQueryable<TProjection> Many<TProjection>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TProjection>> projection, params Expression<Func<TEntity, object>>[] includes)
        {
            var set = CreateIncludedSet(includes).AsNoTracking();

            return set.Where(predicate).Select(projection).AsQueryable();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate = null)
        {
            var set = CreateSet().AsNoTracking();

            return predicate == null ? set.Any() : set.Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            var set = CreateSet().AsNoTracking();

            return predicate == null ? set.Count() : set.Count(predicate);
        }

        protected IDbSet<TEntity> CreateSet()
        {
            return DatabaseContext.CreateSet<TEntity>();
        }
        
        protected IQueryable<TEntity> CreateIncludedSet(IEnumerable<Expression<Func<TEntity, object>>> includes)
        {
            IQueryable<TEntity> set = CreateSet();

            if (includes != null)
                set = includes.Aggregate(set, (current, include) => current.Include(include));

            return set;
        }
        
    }
}
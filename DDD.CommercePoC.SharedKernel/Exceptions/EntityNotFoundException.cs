using System;
using System.Linq.Expressions;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Exceptions
{
    public abstract class EntityNotFoundException : ApplicationException
    {
        protected EntityNotFoundException(string message) : base(message) { }
    }
    public class EntityNotFoundException<TEntity> : EntityNotFoundException where TEntity : IEntity
    {
        public EntityNotFoundException() : base(GenerateMessage(null))
        {
        }

        public EntityNotFoundException(Expression<Func<TEntity, bool>> predicate)
            : base(GenerateMessage(predicate))
        {
        }

        private static string GenerateMessage(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return $"The entity {typeof(TEntity).Name} could not be found";

            return $"The entity {typeof(TEntity).Name} could not be found.\n\tQuery: {predicate}";
        }
    }
}
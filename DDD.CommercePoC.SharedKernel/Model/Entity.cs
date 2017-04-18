﻿using System;
using DDD.CommercePoC.SharedKernel.Model.Interfaces;

namespace DDD.CommercePoC.SharedKernel.Model
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IEntity
    {
        public TId Id { get; protected set; }

        public DateTime Created { get; protected set; }

        public DateTime LastModified { get; protected set; }

        protected Entity(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", nameof(id));
            }

            Id = id;
            Created = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
        }

        // EF requires an empty constructor
        protected Entity()
        {
        }

        // For simple entities, this may suffice
        // As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return Equals(entity);
            }
            // ReSharper disable once BaseObjectEqualsIsObjectEquals : Acceptable for simple types that do not override further
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode : Id cannot change as it is Db generated
            return Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return Id.Equals(other.Id);
        }
    }
}
using System;

namespace SuiteEvents.Domain.Abstracts
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        protected EntityBase()
        { }

        protected EntityBase(Guid id)
        {
            this.Id = id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as EntityBase);
        }

        public virtual bool Equals(EntityBase other)
        {
            return (null != other) && (this.GetType() == other.GetType()) && (other.Id == this.Id);
        }

        public static bool operator ==(EntityBase entity1, EntityBase entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
                return true;

            if ((object)entity1 == null || (object)entity2 == null)
                return false;

            return ((entity1.GetType() == entity2.GetType()) && (entity1.Id == entity2.Id));
        }

        public static bool operator !=(EntityBase entity1, EntityBase entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}

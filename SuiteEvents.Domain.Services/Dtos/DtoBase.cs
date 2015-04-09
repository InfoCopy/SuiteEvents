using System;

namespace SuiteEvents.Domain.Services.Dtos
{
    public class DtoBase
    {
        public virtual Guid Id { get; set; }
        public int Version { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DtoBase);
        }

        public virtual bool Equals(DtoBase other)
        {
            return (null != other) && (this.GetType() == other.GetType()) && (other.Id == this.Id);
        }

        public static bool operator ==(DtoBase dto1, DtoBase dto2)
        {
            if ((object)dto1 == null && (object)dto2 == null)
                return true;

            if ((object)dto1 == null || (object)dto2 == null)
                return false;

            return ((dto1.GetType() == dto2.GetType()) && (dto1.Id == dto2.Id));
        }

        public static bool operator !=(DtoBase dto1, DtoBase dto2)
        {
            return (!(dto1 == dto2));
        }
    }
}

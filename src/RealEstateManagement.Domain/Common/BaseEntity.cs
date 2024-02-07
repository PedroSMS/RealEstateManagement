using System;

namespace RealEstateManagement.Domain.Common;

public class BaseEntity<T> : IAuditableEntity, ISoftDeletableEntity where T : struct
{
    public T Id { get; set; }
    public DateTime CreatedAtUtc { get; set ; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedAtUtc { get; set; }
    public string LastModifiedBy { get; set; }
    public bool IsDeleted { get ; set; }

    public override bool Equals(object obj)
    {
        if (obj is not BaseEntity<T> entity) return false;

        return GetHashCode() == entity.GetHashCode();
    }

    public override int GetHashCode()
    { 
        return HashCode.Combine(GetType(), Id); 
    }
}

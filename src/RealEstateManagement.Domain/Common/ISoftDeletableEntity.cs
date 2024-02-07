namespace RealEstateManagement.Domain.Common;

public interface ISoftDeletableEntity
{
    bool IsDeleted { get; set; }
}

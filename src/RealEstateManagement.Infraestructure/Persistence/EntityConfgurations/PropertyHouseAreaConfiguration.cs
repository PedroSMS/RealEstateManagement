using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Infrastructure.Persistence.EntityConfgurations;

public class PropertyHouseAreaConfiguration : IEntityTypeConfiguration<PropertyHouseArea>
{
    public void Configure(EntityTypeBuilder<PropertyHouseArea> builder)
    {
        builder.ToTable(nameof(PropertyHouseArea), SchemaNames.PROPERTY);
        builder.HasKey(e => new { e.PropertyId, e.HouseAreaId });
    }
}

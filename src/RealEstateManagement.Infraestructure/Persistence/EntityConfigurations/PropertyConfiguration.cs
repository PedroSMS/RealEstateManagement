using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Infrastructure.Persistence.EntityConfigurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable(nameof(Property), SchemaNames.PROPERTY);
        builder.Property(e => e.Description)
            .HasMaxLength(5000);
        builder.Property(e => e.PriceEur)
            .HasPrecision(19, 4);
    }
}
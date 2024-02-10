using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Infrastructure.Persistence.EntityConfgurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable(nameof(City), SchemaNames.GEO);
        builder.Property(e => e.Name).IsRequired();
    }
}

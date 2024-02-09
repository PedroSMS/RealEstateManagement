using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Infrastructure.Persistence.EntityConfgurations;

public class HouseAreaConfiguration : IEntityTypeConfiguration<HouseArea>
{
    public void Configure(EntityTypeBuilder<HouseArea> builder)
    {
        builder.ToTable(nameof(HouseArea), SchemaNames.PROPERTY);
        builder.Property(e => e.Name).IsRequired();
    }
}

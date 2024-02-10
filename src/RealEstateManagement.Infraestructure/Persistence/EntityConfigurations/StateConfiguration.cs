using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Infrastructure.Persistence.EntityConfigurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable(nameof(State), SchemaNames.GEO);
        builder.Property(e => e.Name).IsRequired();
    }
}

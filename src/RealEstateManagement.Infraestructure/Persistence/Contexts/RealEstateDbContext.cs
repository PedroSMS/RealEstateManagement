using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RealEstateManagement.Application.Common.Interfaces;
using RealEstateManagement.Domain.Common;
using RealEstateManagement.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateManagement.Infrastructure.Persistence.Contexts;

public class RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : DbContext(options), IRealEstateDbContext
{
    #region property
    public DbSet<Property> Property { get; set; }
    public DbSet<HouseArea> HouseArea { get; set; }
    public DbSet<Photo> Photo { get; set; }
    #endregion

    #region geo
    public DbSet<Country> Country { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<City> City { get; set; }
    #endregion

    public override int SaveChanges() => SaveChangesAsync(CancellationToken.None).Result;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddAuditToEntities();

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

            entityType.GetProperties()
                .Where(p => p.ClrType == typeof(string))
                .ToList()
                .ForEach(p => p.SetMaxLength(255));

            if (typeof(ISoftDeletableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<bool>(nameof(ISoftDeletableEntity.IsDeleted))
                    .HasDefaultValue(false);
                entityType.AddSoftDeleteQueryFilter();
            }

            if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<string>(nameof(IAuditableEntity.CreatedBy))
                    .HasMaxLength(50)
                    .IsRequired();
                modelBuilder.Entity(entityType.ClrType)
                    .Property<string>(nameof(IAuditableEntity.LastModifiedBy))
                    .HasMaxLength(50)
                    .IsRequired();
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    private void AddAuditToEntities()
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch(entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAtUtc = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "RealEstate"; // Add a way to store user name
                    entry.Entity.LastModifiedAtUtc = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = "RealEstate"; // Add a way to store user name
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedAtUtc = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = "RealEstate"; // Add a way to store user name
                    break;
            }
        }
    }
}

public static class GlobalQueryExtensions
{
    public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityType)
    {
        var method = typeof(GlobalQueryExtensions)
            .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
            .MakeGenericMethod(entityType.ClrType);

        var filter = method.Invoke(null, Array.Empty<object>());
        entityType.SetQueryFilter((LambdaExpression)filter);
        entityType.AddIndex(entityType.FindProperty(nameof(ISoftDeletableEntity.IsDeleted)));
    }

    private static LambdaExpression GetSoftDeleteFilter<TEntity>()
        where TEntity : class, ISoftDeletableEntity
    {
        Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
        return filter;
    }
}

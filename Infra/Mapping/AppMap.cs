using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Mapping;

[ExcludeFromCodeCoverage]
public class AppMap : IEntityTypeConfiguration<AppEntity>
{
    public void Configure(EntityTypeBuilder<AppEntity> builder)
    {
        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.Id)
            .IsRequired();

        builder
            .Property(user => user.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(user => user.Price)
            .HasPrecision(18, 2)
            .IsRequired();
    }
}

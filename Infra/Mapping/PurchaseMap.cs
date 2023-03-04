using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Mapping;

[ExcludeFromCodeCoverage]
public class PurchaseMap : IEntityTypeConfiguration<PurchaseEntity>
{
    public void Configure(EntityTypeBuilder<PurchaseEntity> builder)
    {
        builder.HasKey(purchase => purchase.Id);

        builder
            .Property(purchase => purchase.Id)
            .IsRequired();

        builder
            .Property(purchase => purchase.PersonId)
            .IsRequired();

        builder
            .HasOne(purchase => purchase.App)
            .WithMany(purchase => purchase.Purchases)
            .HasForeignKey(purchase => purchase.AppId);

        builder
            .HasOne(purchase => purchase.Transaction)
            .WithOne(purchase => purchase.Purchase)
            .HasForeignKey<PurchaseEntity>(purchase => purchase.TransactionId);
    }
}

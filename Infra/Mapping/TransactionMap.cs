using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Mapping;

public class TransactionMap : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.HasKey(transaction => transaction.Id);

        builder
            .Property(transaction => transaction.Id)
            .IsRequired();

        builder
            .Property(transaction => transaction.NumberCard)
            .HasMaxLength(16)
            .IsRequired();

        builder
            .Property(transaction => transaction.NameOnCreditCard)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(transaction => transaction.Validate)
            .HasMaxLength(7)
            .IsRequired();

        builder
            .Property(transaction => transaction.Cvc)
            .HasMaxLength(3)
            .IsRequired();

        builder
            .Property(transaction => transaction.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(transaction => transaction.PaymentStatus)
            .HasConversion(new EnumToStringConverter<PaymentStatus>())
            .IsRequired();
    }
}

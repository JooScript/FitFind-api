using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class PaymentTransactionConfiguration : IEntityTypeConfiguration<TbPaymentTransaction>
{
    public void Configure(EntityTypeBuilder<TbPaymentTransaction> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_PaymentTransactions");

        builder.ToTable("TbPaymentTransactions", "payments");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Amount)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.GatewayTransactionId)
            .HasMaxLength(100);
        builder.Property(e => e.PaymentId);
        builder.Property(e => e.ResponseCode)
            .HasMaxLength(20);
        builder.Property(e => e.ResponseMessage);

        builder.Property(e => e.TransactionDate)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.TransactionType)
            .HasMaxLength(20);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Payment)
            .WithMany(p => p.TbPaymentTransactions)
            .HasForeignKey(d => d.PaymentId)
            .HasConstraintName("FK_PaymentTransactions_Payment");




        builder.HasOne<AppUser>()
.WithMany(p => p.TbPaymentTransactions)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbPaymentTransactions_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbPaymentTransactions)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbPaymentTransactions_UserUpdator");

    }
}
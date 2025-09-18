using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<TbPayment>
{
    public void Configure(EntityTypeBuilder<TbPayment> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Payments");

        builder.ToTable("TbPayments", "payments");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Amount)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.BillingAddressId);
        builder.Property(e => e.Currency)
            .HasMaxLength(3)
            .HasDefaultValue("USD");
        builder.Property(e => e.GatewayResponse);
        builder.Property(e => e.OrderId);
        builder.Property(e => e.PaymentDate)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.PaymentMethod)
            .HasMaxLength(50);
        builder.Property(e => e.PaymentStatus)
            .HasMaxLength(20);
        builder.Property(e => e.TransactionId)
            .HasMaxLength(100);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.BillingAddress)
            .WithMany(p => p.TbPayments)
            .HasForeignKey(d => d.BillingAddressId)
            .HasConstraintName("FK_Payments_BillingAddress");

        builder.HasOne(d => d.Order)
            .WithMany(p => p.TbPayments)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("FK_Payments_Order");





        builder.HasOne<AppUser>()
.WithMany(p => p.TbPayments)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbPayments_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbPayments)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbPayments_UserUpdator");

    }
}
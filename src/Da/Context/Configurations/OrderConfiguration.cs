using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<TbOrder>
{
    public void Configure(EntityTypeBuilder<TbOrder> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Orders");

        builder.ToTable("TbOrders", "orders");

        builder.HasIndex(e => e.UserId, "idx_orders_user_id");

        #region Properties

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.BillingAddressId);

        builder.Property(e => e.DiscountAmount)
            .HasDefaultValue(0.00m)
            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.IpAddress)
            .HasMaxLength(45);

        builder.Property(e => e.Notes);

        builder.Property(e => e.OrderDate)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.OrderNumber)
            .HasMaxLength(50);

        builder.Property(e => e.OrderStatus)
            .HasMaxLength(20);

        builder.Property(e => e.PaymentMethod)
            .HasMaxLength(50);

        builder.Property(e => e.ShippingAddressId);

        builder.Property(e => e.ShippingAmount)
            .HasDefaultValue(0.00m)
            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.ShippingMethod)
            .HasMaxLength(50);

        builder.Property(e => e.TaxAmount)
            .HasDefaultValue(0.00m)
            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.TotalAmount)
            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.UserId);

        builder.Property(e => e.CreatedBy);

        builder.Property(e => e.UpdatedBy);


        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        #endregion

        #region Relationships

        builder.HasOne(d => d.BillingAddress)
            .WithMany(p => p.TbOrderBillingAddresses)
            .HasForeignKey(d => d.BillingAddressId)
            .HasConstraintName("FK_OrderBillingAddresses_BillingAddress");

        builder.HasOne(d => d.ShippingAddress)
            .WithMany(p => p.TbOrderShippingAddresses)
            .HasForeignKey(d => d.ShippingAddressId)
            .HasConstraintName("FK_OrderShippingAddresses_ShippingAddress");

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbOrders)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Orders_User");

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbOrders)
            .HasForeignKey(d => d.CreatedBy)
            .HasConstraintName("FK_TbOrders_UserCreator");

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbOrders)
            .HasForeignKey(d => d.UpdatedBy)
            .HasConstraintName("FK_TbOrders_UserUpdator");

        #endregion

    }
}
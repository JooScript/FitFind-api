using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<TbOrderItem>
{
    public void Configure(EntityTypeBuilder<TbOrderItem> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Order_Items");

        builder.ToTable("TbOrderItems", "orders");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.DiscountAmount)
            .HasDefaultValue(0.00m)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.ItemStatus)
            .HasMaxLength(20);
        builder.Property(e => e.OrderId);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.Quantity);
        builder.Property(e => e.TaxAmount)
            .HasDefaultValue(0.00m)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.TotalPrice)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.UnitPrice)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.VariationId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Order)
            .WithMany(p => p.TbOrderItems)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("FK_OrderItems_Order");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbOrderItems)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_OrderItems_Product");

        builder.HasOne(d => d.Variation)
            .WithMany(p => p.TbOrderItems)
            .HasForeignKey(d => d.VariationId)
            .HasConstraintName("FK_OrderItems_Variation");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbOrderItems)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbOrderItems_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbOrderItems)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbOrderItems_UserUpdator");


    }
}
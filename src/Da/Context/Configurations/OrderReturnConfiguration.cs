using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class OrderReturnConfiguration : IEntityTypeConfiguration<TbOrderReturn>
{
    public void Configure(EntityTypeBuilder<TbOrderReturn> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_OrderReturns");

        builder.ToTable("TbOrderReturns", "orders");

        builder.HasIndex(e => e.OrderItemId, "IX_tb_order_returns_order_item_id");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.OrderItemId);
        builder.Property(e => e.ProcessedAt);
        builder.Property(e => e.Reason)
            .HasMaxLength(255);
        builder.Property(e => e.RequestedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.Status)
            .HasMaxLength(20);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.OrderItem)
            .WithMany(p => p.TbOrderReturns)
            .HasForeignKey(d => d.OrderItemId)
            .HasConstraintName("FK_OrderReturns_OrderItem");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbOrderReturns)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbOrderReturns_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbOrderReturns)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbOrderReturns_UserUpdator");


    }
}
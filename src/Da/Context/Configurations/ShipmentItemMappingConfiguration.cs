using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ShipmentItemMappingConfiguration : IEntityTypeConfiguration<TbShipmentItemMapping>
{
    public void Configure(EntityTypeBuilder<TbShipmentItemMapping> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_ShipmentItemMappings");

        builder.ToTable("TbShipmentItemMappings", "shipping");

        builder.HasIndex(e => e.OrderItemId, "IX_tb_shipment_item_mapping_order_item_id");

        builder.HasIndex(e => e.ShipmentId, "IX_tb_shipment_item_mapping_shipment_id");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.OrderItemId);
        builder.Property(e => e.Quantity);
        builder.Property(e => e.ShipmentId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.OrderItem).WithMany(p => p.TbShipmentItemMappings)
            .HasForeignKey(d => d.OrderItemId)
            .HasConstraintName("FK_ShipmentItemMappings_OrderItem");

        builder.HasOne(d => d.Shipment).WithMany(p => p.TbShipmentItemMappings)
            .HasForeignKey(d => d.ShipmentId)
            .HasConstraintName("FK_ShipmentItemMappings_Shipment");


        builder.HasOne<AppUser>()
.WithMany(p => p.TbShipmentItemMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbShipmentItemMappings_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbShipmentItemMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbShipmentItemMappings_UserUpdator");

    }
}
using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<TbShipment>
{
    public void Configure(EntityTypeBuilder<TbShipment> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Shipments");

        builder.ToTable("TbShipments", "shipping");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.ActualDeliveryDate);
        builder.Property(e => e.Carrier)
            .HasMaxLength(50);
        builder.Property(e => e.EstimatedDeliveryDate);
        builder.Property(e => e.OrderId);
        builder.Property(e => e.ShipmentDate);
        builder.Property(e => e.ShipmentStatus)
            .HasMaxLength(20);
        builder.Property(e => e.ShippingCost)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.ShippingMethodId);
        builder.Property(e => e.TrackingNumber)
            .HasMaxLength(100);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Order).WithMany(p => p.TbShipments)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("FK_Shipments_Order");

        builder.HasOne(d => d.ShippingMethod).WithMany(p => p.TbShipments)
            .HasForeignKey(d => d.ShippingMethodId)
            .HasConstraintName("FK_Shipments_ShippingMethod");




        builder.HasOne<AppUser>()
.WithMany(p => p.TbShipments)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbShipments_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbShipments)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbShipments_UserUpdator");


    }
}
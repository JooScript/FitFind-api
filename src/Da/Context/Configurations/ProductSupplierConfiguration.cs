using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ProductSupplierConfiguration : IEntityTypeConfiguration<TbProductSupplier>
{
    public void Configure(EntityTypeBuilder<TbProductSupplier> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("TbProductSuppliers", "inventory");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CostPrice)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.IsPrimary)
            .HasDefaultValue(false);
        builder.Property(e => e.LeadTimeDays);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.SupplierId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbProductSuppliers)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductSuppliers_Product");

        builder.HasOne(d => d.Supplier)
            .WithMany(p => p.TbProductSuppliers)
            .HasForeignKey(d => d.SupplierId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductSuppliers_Supplier");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductSuppliers)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbProductSuppliers_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductSuppliers)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbProductSuppliers_UserUpdator");

    }
}
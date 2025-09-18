using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<TbProduct>
{
    public void Configure(EntityTypeBuilder<TbProduct> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Products");

        builder.ToTable("TbProducts", "products");

        builder.HasIndex(e => e.Sku, "UQ_Product_Sku").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CostPrice)
            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.Description);

        builder.Property(e => e.Height)
            .HasColumnType("decimal(10, 2)");

        builder.Property(e => e.IsDigital)
            .HasDefaultValue(false);

        builder.Property(e => e.Length)
            .HasColumnType("decimal(10, 2)");

        builder.Property(e => e.LowStockThreshold)
            .HasDefaultValue(5);

        builder.Property(e => e.Name)
            .HasMaxLength(100);

        builder.Property(e => e.Price)
            .HasColumnType("decimal(12, 2)");

        builder.Property(e => e.ShortDescription)
            .HasMaxLength(255);

        builder.Property(e => e.Sku)
            .HasMaxLength(50);

        builder.Property(e => e.StockQuantity)
            .HasDefaultValue(0);

        builder.Property(e => e.UpdatedAt);

        builder.Property(e => e.Weight)
            .HasColumnType("decimal(10, 2)");

        builder.Property(e => e.Width)
            .HasColumnType("decimal(10, 2)");

        builder.Property(e => e.CurrentState).HasDefaultValue(1);


        builder.HasOne<AppUser>()
.WithMany(p => p.TbProducts)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbProducts_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbProducts)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbProducts_UserUpdator");

    }
}
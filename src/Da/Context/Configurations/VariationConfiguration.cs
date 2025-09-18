using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class VariationConfiguration : IEntityTypeConfiguration<TbVariation>
{
    public void Configure(EntityTypeBuilder<TbVariation> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Variations");

        builder.ToTable("TbVariations", "products");

        builder.HasIndex(e => e.Sku, "UQ_Variation").IsUnique();

        builder.Property(e => e.Id)
             .HasDefaultValueSql("NEWSEQUENTIALID()")
             .ValueGeneratedOnAdd();

        builder.Property(e => e.PriceAdjustment)
            .HasDefaultValue(0.00m)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.ProductId);
        builder.Property(e => e.Sku)
            .HasMaxLength(50);
        builder.Property(e => e.StockQuantity)
            .HasDefaultValue(0);
        builder.Property(e => e.VariationName)
            .HasMaxLength(100);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product).WithMany(p => p.TbVariations)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_Variations_Product");


        builder.HasOne<AppUser>()
.WithMany(p => p.TbVariations)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbVariations_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbVariations)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbVariations_UserUpdator");

    }
}
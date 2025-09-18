using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class DiscountProductMappingConfiguration : IEntityTypeConfiguration<TbDiscountProductMapping>
{
    public void Configure(EntityTypeBuilder<TbDiscountProductMapping> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_tb_discount_products");

        builder.ToTable("TbDiscountProductMappings", "marketing");

        builder.HasIndex(e => e.DiscountId, "IX_tb_discount_product_mapping_discount_id");

        builder.HasIndex(e => e.ProductId, "IX_tb_discount_product_mapping_product_id");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.DiscountId);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Discount)
            .WithMany(p => p.TbDiscountProductMappings)
            .HasForeignKey(d => d.DiscountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DiscountProducts_Discount");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbDiscountProductMappings)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DiscountProducts_Product");





        builder.HasOne<AppUser>()
.WithMany(p => p.TbDiscountProductMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbDiscountProductMapping_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbDiscountProductMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbDiscountProductMapping_UserUpdator");




    }
}
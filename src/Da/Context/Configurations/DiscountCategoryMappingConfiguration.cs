using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class DiscountCategoryMappingConfiguration : IEntityTypeConfiguration<TbDiscountCategoryMapping>
{
    public void Configure(EntityTypeBuilder<TbDiscountCategoryMapping> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_tb_discount_categories");

        builder.ToTable("TbDiscountCategoryMappings", "marketing");

        builder.HasIndex(e => e.CategoryId, "IX_tb_discount_category_mapping_category_id");

        builder.HasIndex(e => e.DiscountId, "IX_tb_discount_category_mapping_discount_id");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CategoryId);
        builder.Property(e => e.DiscountId);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Category)
            .WithMany(p => p.TbDiscountCategoryMappings)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DiscountCategories_Category");

        builder.HasOne(d => d.Discount)
            .WithMany(p => p.TbDiscountCategoryMappings)
            .HasForeignKey(d => d.DiscountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DiscountCategories_Discount");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbDiscountCategoryMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbDiscountCategoryMappings_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbDiscountCategoryMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbDiscountCategoryMappings_UserUpdator");


    }
}
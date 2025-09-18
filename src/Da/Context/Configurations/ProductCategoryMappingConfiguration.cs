using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ProductCategoryMappingConfiguration : IEntityTypeConfiguration<TbProductCategoryMapping>
{
    public void Configure(EntityTypeBuilder<TbProductCategoryMapping> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("TbProductCategoryMappings", "products");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CategoryId);
        builder.Property(e => e.IsPrimary)
            .HasDefaultValue(false);
        builder.Property(e => e.ProductId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Category)
            .WithMany(p => p.TbProductCategoryMappings)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductCategoryMappings_Category");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.TbProductCategoryMappings)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductCategoryMappings_Product");




        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductCategoryMappings)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbProductCategoryMappings_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbProductCategoryMappings)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbProductCategoryMappings_UserUpdator");


    }
}
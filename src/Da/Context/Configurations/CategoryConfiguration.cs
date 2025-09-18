using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<TbCategory>
{
    public void Configure(EntityTypeBuilder<TbCategory> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Category");

        builder.ToTable("TbCategories", "products");

        builder.HasIndex(e => e.Slug, "UQ_Category_Slug").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Description);
        builder.Property(e => e.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(e => e.Name)
            .HasMaxLength(50);
        builder.Property(e => e.ParentCategoryId);
        builder.Property(e => e.Slug)
            .HasMaxLength(100);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);



        builder.HasOne<AppUser>()
.WithMany(p => p.TbCategories)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbCategories_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbCategories)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbCategories_UserUpdator");



        builder.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
            .HasForeignKey(d => d.ParentCategoryId)
            .HasConstraintName("FK_InverseParentCategories_ParentCategory");
    }
}
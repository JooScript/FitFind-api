using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<TbImage>
{
    public void Configure(EntityTypeBuilder<TbImage> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Images");

        builder.ToTable("TbImages", "products");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.AltText)
            .HasMaxLength(100);
        builder.Property(e => e.DisplayOrder)
            .HasDefaultValue(0);
        builder.Property(e => e.ImageUrl)
            .HasMaxLength(255);
        builder.Property(e => e.IsPrimary)
            .HasDefaultValue(false);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product).WithMany(p => p.TbImages)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_Images_Product");




        builder.HasOne<AppUser>()
.WithMany(p => p.TbImages)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbImages_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbImages)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbImages_UserUpdator");


    }
}
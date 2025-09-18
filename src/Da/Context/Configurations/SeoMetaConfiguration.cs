using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class SeoMetaConfiguration : IEntityTypeConfiguration<TbSeoMetum>
{
    public void Configure(EntityTypeBuilder<TbSeoMetum> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("TbSeoMeta", "products");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CanonicalUrl)
            .HasMaxLength(255);
        builder.Property(e => e.MetaDescription)
            .HasMaxLength(255);
        builder.Property(e => e.MetaKeywords)
            .HasMaxLength(255);
        builder.Property(e => e.MetaTitle)
            .HasMaxLength(100);
        builder.Property(e => e.ProductId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product).WithMany(p => p.TbSeoMeta)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SeoMeta_Product");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbSeoMeta)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbSeoMeta_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbSeoMeta)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbSeoMeta_UserUpdator");

    }
}
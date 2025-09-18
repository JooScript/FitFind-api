using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class WishlistConfiguration : IEntityTypeConfiguration<TbWishlist>
{
    public void Configure(EntityTypeBuilder<TbWishlist> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Wishlists");

        builder.ToTable("TbWishlists", "customers");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.IsDefault)
            .HasDefaultValue(false);
        builder.Property(e => e.Name)
            .HasMaxLength(50);
        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.UserId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbWishlists)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Wishlists_User");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbWishlists)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbWishlists_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbWishlists)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbWishlists_UserUpdator");

    }
}
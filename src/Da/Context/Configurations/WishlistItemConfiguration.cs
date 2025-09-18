using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class WishlistItemConfiguration : IEntityTypeConfiguration<TbWishlistItem>
{
    public void Configure(EntityTypeBuilder<TbWishlistItem> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Wishlist_Item");

        builder.ToTable("TbWishlistItems", "customers");

        builder.Property(e => e.Id)
          .HasDefaultValueSql("NEWSEQUENTIALID()")
          .ValueGeneratedOnAdd();
        builder.Property(e => e.AddedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.ProductId);
        builder.Property(e => e.WishlistId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product).WithMany(p => p.TbWishlistItems)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_WishlistItems_Product");

        builder.HasOne(d => d.Wishlist).WithMany(p => p.TbWishlistItems)
            .HasForeignKey(d => d.WishlistId)
            .HasConstraintName("FK_WishlistItems_Wishlist");


        builder.HasOne<AppUser>()
.WithMany(p => p.TbWishlistItems)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbWishlistItems_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbWishlistItems)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbWishlistItems_UserUpdator");



    }
}
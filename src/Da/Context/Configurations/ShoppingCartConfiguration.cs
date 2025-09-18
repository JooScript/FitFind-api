using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class ShoppingCartConfiguration : IEntityTypeConfiguration<TbShoppingCart>
{
    public void Configure(EntityTypeBuilder<TbShoppingCart> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_ShoppingCarts");

        builder.ToTable("TbShoppingCarts", "customers");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.SessionId)
            .HasMaxLength(100);
        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.UserId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne<AppUser>().WithMany(p => p.TbShoppingCarts)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_ShoppingCarts_User");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbShoppingCarts)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbShoppingCarts_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbShoppingCarts)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbShoppingCarts_UserUpdator");


    }
}
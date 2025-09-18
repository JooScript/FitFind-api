using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<TbCartItem>
{
    public void Configure(EntityTypeBuilder<TbCartItem> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Cart_Items");

        builder.ToTable("TbCartItems", "customers");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.CartId);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.Quantity);
        builder.Property(e => e.VariationId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Cart).WithMany(p => p.TbCartItems)
            .HasForeignKey(d => d.CartId)
            .HasConstraintName("FK_TbCartItems_Cart");

        builder.HasOne(d => d.Product).WithMany(p => p.TbCartItems)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_TbCartItems_Product");

        builder.HasOne(d => d.Variation).WithMany(p => p.TbCartItems)
            .HasForeignKey(d => d.VariationId)
            .HasConstraintName("FK_TbCartItems_Variation");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbCartItems)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbCartItems_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbCartItems)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbCartItems_UserUpdator");



    }
}
using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<TbDiscount>
{
    public void Configure(EntityTypeBuilder<TbDiscount> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Discount");

        builder.ToTable("TbDiscounts", "marketing");

        builder.HasIndex(e => e.Code, "UQ_Discount").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Amount)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.Code)
            .HasMaxLength(50);
        builder.Property(e => e.CurrentUses)
            .HasDefaultValue(0);
        builder.Property(e => e.Description);
        builder.Property(e => e.DiscountType)
            .HasMaxLength(20);
        builder.Property(e => e.EndDate);

        builder.Property(e => e.IsSingleUse)
            .HasDefaultValue(false);
        builder.Property(e => e.MaxUses);
        builder.Property(e => e.MinOrderAmount)
            .HasDefaultValue(0.00m)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.Name)
            .HasMaxLength(100);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.Property(e => e.StartDate);




        builder.HasOne<AppUser>()
.WithMany(p => p.TbDiscounts)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbDiscounts_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbDiscounts)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbDiscounts_UserUpdator");


    }
}
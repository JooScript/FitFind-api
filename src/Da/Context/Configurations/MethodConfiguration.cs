using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class MethodConfiguration : IEntityTypeConfiguration<TbMethod>
{
    public void Configure(EntityTypeBuilder<TbMethod> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Methods");

        builder.ToTable("TbMethods", "shipping");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CalculationMethod)
            .HasMaxLength(20);
        builder.Property(e => e.Cost)
            .HasColumnType("decimal(12, 2)");
        builder.Property(e => e.Description);

        builder.Property(e => e.Name)
            .HasMaxLength(50);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);




        builder.HasOne<AppUser>()
.WithMany(p => p.TbMethods)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbMethods_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbMethods)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbMethods_UserUpdator");
    }
}
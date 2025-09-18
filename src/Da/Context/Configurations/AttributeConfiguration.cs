using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class AttributeConfiguration : IEntityTypeConfiguration<TbAttribute>
{
    public void Configure(EntityTypeBuilder<TbAttribute> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Attributes");

        builder.ToTable("TbAttributes", "products");

        builder.HasIndex(e => e.Name, "UQ_AttributeName").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasMaxLength(50);

        builder.Property(e => e.Description);

        builder.Property(e => e.CurrentState)
            .HasDefaultValue(1);

        builder.HasOne<AppUser>()
      .WithMany(p => p.TbAttributes)
      .HasForeignKey(d => d.CreatedBy)
      .HasConstraintName("FK_TbAttributes_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbAttributes)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbAttributes_UserUpdator");

    }
}
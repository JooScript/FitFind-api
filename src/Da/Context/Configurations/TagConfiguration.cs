using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<TbTag>
{
    public void Configure(EntityTypeBuilder<TbTag> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Tags");

        builder.ToTable("TbTags", "products");

        builder.HasIndex(e => e.Name, "UQ_Tags").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Name)
            .HasMaxLength(50);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);



        builder.HasOne<AppUser>()
.WithMany(p => p.TbTags)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbTags_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbTags)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbTags_UserUpdator");


    }
}
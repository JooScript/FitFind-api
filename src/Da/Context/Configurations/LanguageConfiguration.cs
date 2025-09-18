using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<TbLanguage>
{
    public void Configure(EntityTypeBuilder<TbLanguage> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Languages");

        builder.ToTable("TbLanguages", "core");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.IsDefault)
            .HasDefaultValue(false);
        builder.Property(e => e.LanguageCode)
            .HasMaxLength(10);
        builder.Property(e => e.Name)
            .HasMaxLength(50);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);




        builder.HasOne<AppUser>()
.WithMany(p => p.TbLanguages)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbLanguages_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbLanguages)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbLanguages_UserUpdator");


    }
}
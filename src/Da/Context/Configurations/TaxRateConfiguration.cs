using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class TaxRateConfiguration : IEntityTypeConfiguration<TbTaxRate>
{
    public void Configure(EntityTypeBuilder<TbTaxRate> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_TaxRates");

        builder.ToTable("TbTaxRates", "marketing");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Country)
            .HasMaxLength(2);
        builder.Property(e => e.IsActive)
            .HasDefaultValue(true);
        builder.Property(e => e.IsDefault)
            .HasDefaultValue(false);
        builder.Property(e => e.Rate)
            .HasColumnType("decimal(5, 4)");
        builder.Property(e => e.State)
            .HasMaxLength(2);
        builder.Property(e => e.TaxName)
            .HasMaxLength(50);
        builder.Property(e => e.ZipCode)
            .HasMaxLength(10);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);



        builder.HasOne<AppUser>()
.WithMany(p => p.TbTaxRates)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbTaxRates_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbTaxRates)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbTaxRates_UserUpdator");

    }
}
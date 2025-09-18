using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<TbAddress>
{
    public void Configure(EntityTypeBuilder<TbAddress> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Addresses");

        builder.ToTable("TbAddresses", "core");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.AddressType)
            .HasMaxLength(20);

        builder.Property(e => e.City)
            .HasMaxLength(50);

        builder.Property(e => e.Country)
            .HasMaxLength(50);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.IsDefault)
            .HasDefaultValue(false);

        builder.Property(e => e.PostalCode)
            .HasMaxLength(20);

        builder.Property(e => e.State)
            .HasMaxLength(50);

        builder.Property(e => e.StreetAddress1)
            .HasMaxLength(100);

        builder.Property(e => e.StreetAddress2)
            .HasMaxLength(100);

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.UserId);

        builder.Property(e => e.CurrentState)
            .HasDefaultValue(1);

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbAddresses)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Addresses_User");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbAddresses)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbAddresses_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbAddresses)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbAddresses_UserUpdator");

    }
}
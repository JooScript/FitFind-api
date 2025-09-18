using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<TbSupplier>
{
    public void Configure(EntityTypeBuilder<TbSupplier> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Suppliers");

        builder.ToTable("TbSuppliers", "inventory");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Address);
        builder.Property(e => e.ContactPerson)
            .HasMaxLength(100);
        builder.Property(e => e.Email)
            .HasMaxLength(100);

        builder.Property(e => e.Name)
            .HasMaxLength(100);
        builder.Property(e => e.Phone)
            .HasMaxLength(20);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);




        builder.HasOne<AppUser>()
.WithMany(p => p.TbSuppliers)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbSuppliers_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbSuppliers)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbSuppliers_UserUpdator");

    }
}
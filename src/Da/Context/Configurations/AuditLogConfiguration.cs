using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<TbAuditLog>
{
    public void Configure(EntityTypeBuilder<TbAuditLog> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_AuditLogs");

        builder.ToTable("TbAuditLogs", "core");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Action)
            .HasMaxLength(100);

        builder.Property(e => e.Details)
            .HasMaxLength(int.MaxValue);

        builder.Property(e => e.Entity)
            .HasMaxLength(100);

        builder.Property(e => e.EntityId);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.Property(e => e.CreatedBy);



        builder.HasOne<AppUser>()
.WithMany(p => p.TbAuditLogs)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbAuditLogs_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbAuditLogs)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbAuditLogs_UserUpdator");

    }
}
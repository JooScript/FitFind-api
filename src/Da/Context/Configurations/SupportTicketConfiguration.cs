using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ECommerce.Core.Enums.Status;

namespace ECommerce.Da.Context.Configurations;

public class SupportTicketConfiguration : IEntityTypeConfiguration<TbSupportTicket>
{
    public void Configure(EntityTypeBuilder<TbSupportTicket> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_SupportTickets");

        builder.ToTable("TbSupportTickets", "core");

        #region Properties

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Message)
            .HasMaxLength(5000);

        builder.Property(e => e.Subject)
            .HasMaxLength(100);

        builder.Property(e => e.CurrentState)
            .HasDefaultValue(1);

        builder.Property(e => e.Priority)
            .HasDefaultValue(enPriorityLevel.Medium);

        builder.Property(e => e.AssignedTo);

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.CreatedBy);

        builder.Property(e => e.CreatedBy);

        #endregion

        #region Relationships

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbSupportTickets)
            .HasForeignKey(d => d.CreatedBy)
            .HasConstraintName("FK_TbSupportTickets_UserCreator");

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbSupportTickets)
            .HasForeignKey(d => d.UpdatedBy)
            .HasConstraintName("FK_TbSupportTickets_UserUpdator");

        #endregion

    }
}
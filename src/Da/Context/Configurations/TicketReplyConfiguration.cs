using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class TicketReplyConfiguration : IEntityTypeConfiguration<TbTicketReply>
{
    public void Configure(EntityTypeBuilder<TbTicketReply> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_TicketReplies");

        builder.ToTable("TbTicketReplies", "core");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Message);
        builder.Property(e => e.RepliedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.TicketId);
        builder.Property(e => e.UserId);

        builder.HasOne(d => d.Ticket).WithMany(p => p.TbTicketReplies)
            .HasForeignKey(d => d.TicketId)
            .HasConstraintName("FK_TicketReplies_Ticket");

        builder.HasOne<AppUser>().WithMany(p => p.TbTicketReplies)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_TicketReplies_User");
        builder.Property(e => e.CurrentState).HasDefaultValue(1);


        builder.HasOne<AppUser>()
.WithMany(p => p.TbTicketReplies)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbTicketReplies_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbTicketReplies)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbTicketReplies_UserUpdator");

    }
}
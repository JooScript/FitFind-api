using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class UserActivityConfiguration : IEntityTypeConfiguration<TbUserActivity>
{
    public void Configure(EntityTypeBuilder<TbUserActivity> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_UserActivities");

        builder.ToTable("TbUserActivities", "core");

        builder.Property(e => e.Id)
           .HasDefaultValueSql("NEWSEQUENTIALID()")
           .ValueGeneratedOnAdd();
        builder.Property(e => e.Action)
            .HasMaxLength(100);
        builder.Property(e => e.IpAddress)
            .HasMaxLength(45);
        builder.Property(e => e.Page)
            .HasMaxLength(255);
        builder.Property(e => e.Timestamp)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.UserId);
        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne<AppUser>().WithMany(p => p.TbUserActivities)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_UserActivities_User");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbUserActivities)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbUserActivities_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbUserActivities)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbUserActivities_UserUpdator");

    }
}
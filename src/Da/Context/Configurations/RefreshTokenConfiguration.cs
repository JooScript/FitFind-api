using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<TbRefreshToken>
{
    public void Configure(EntityTypeBuilder<TbRefreshToken> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_TbRefreshToken");

        builder.ToTable("TbRefreshTokens", "core");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Token)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasIndex(e => e.Token)
            .IsUnique()
            .HasDatabaseName("UQ_TbRefreshToken_Token");

        builder.Property(e => e.UserId).IsRequired();

        builder.Property(e => e.Expires).IsRequired();

        builder.Property(e => e.CurrentState)
            .HasDefaultValue(1);

        builder.HasOne<AppUser>()
            .WithMany(u => u.TbRefreshTokens)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_TbRefreshTokens_User");

        builder.HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_TbRefreshTokens_UserCreator");

        builder.HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(e => e.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_TbRefreshTokens_UserUpdator");
    }
}

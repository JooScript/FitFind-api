using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<TbSubscription>
{
    public void Configure(EntityTypeBuilder<TbSubscription> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Subscriptions");

        builder.ToTable("TbSubscriptions", "orders");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("(sysdatetimeoffset())");
        builder.Property(e => e.Frequency)
            .HasMaxLength(20);
        builder.Property(e => e.NextBillingDate);
        builder.Property(e => e.ProductId);
        builder.Property(e => e.Status)
            .HasMaxLength(20);
        builder.Property(e => e.UserId);

        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Product).WithMany(p => p.TbSubscriptions)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("FK_Subscriptions_Product");

        builder.HasOne<AppUser>().WithMany(p => p.TbSubscriptions)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Subscriptions_User");



        builder.HasOne<AppUser>()
.WithMany(p => p.TbSubscriptions)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbSubscriptions_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbSubscriptions)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbSubscriptions_UserUpdator");

    }
}
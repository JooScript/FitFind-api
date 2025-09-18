using ECommerce.Da.Identity;
using ECommerce.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Da.Context.Configurations;

public class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<TbOrderStatusHistory>
{
    public void Configure(EntityTypeBuilder<TbOrderStatusHistory> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_OrderStatusHistories");

        builder.ToTable("TbOrderStatusHistories", "orders");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();
        builder.Property(e => e.Comments);
        builder.Property(e => e.OrderId);

        builder.Property(e => e.StatusDate)
            .HasDefaultValueSql("(sysdatetimeoffset())");

        builder.Property(e => e.UserId);


        builder.Property(e => e.CurrentState).HasDefaultValue(1);

        builder.HasOne(d => d.Order)
            .WithMany(p => p.TbOrderStatusHistories)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("FK_OrderStatusHistories_Order");

        builder.HasOne<AppUser>()
            .WithMany(p => p.TbOrderStatusHistories)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_OrderStatusHistories_User");




        builder.HasOne<AppUser>()
.WithMany(p => p.TbOrderStatusHistories)
.HasForeignKey(d => d.CreatedBy)
.HasConstraintName("FK_TbOrderStatusHistories_UserCreator");

        builder.HasOne<AppUser>()
.WithMany(p => p.TbOrderStatusHistories)
.HasForeignKey(d => d.UpdatedBy)
.HasConstraintName("FK_TbOrderStatusHistories_UserUpdator");

    }
}